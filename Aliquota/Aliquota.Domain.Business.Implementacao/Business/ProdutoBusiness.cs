using Aliquota.Domain.Business.IBusiness;
using Aliquota.Domain.Business.Implementacao.Base;
using Aliquota.Domain.Business.Implementacao.Business.IRFactory;
using Aliquota.Domain.Entities.DTO;
using Aliquota.Domain.Entities.Entidades;
using Aliquota.Domain.Repository.IRepositorios;
using Aliquota.Domin.Util.Enum;
using Aliquota.Domin.Util.Excecoes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.Business.Implementacao.Business
{
    public class ProdutoBusiness : BusinessCrudBase<Produto>, IProdutoBusiness
    {
        private readonly ITipoProdutoBusiness _tipoProdutoBusiness;
        private readonly ISituacaoProdutoBusiness _situacaoProdutoBusiness;
        public ProdutoBusiness(IProdutoRepositorio produtoRepository, ITipoProdutoBusiness tipoProdutoBusiness, ISituacaoProdutoBusiness situacaoProdutoBusiness)
            : base()
        {
            _repository = produtoRepository;
            _tipoProdutoBusiness = tipoProdutoBusiness;
            _situacaoProdutoBusiness = situacaoProdutoBusiness;
        }

        public async Task<Produto> Criar(ProdutoDto item, Cliente cliente)
        {
            if(item.ValorInvestido <= 0m)
            {
                throw new BusinessException(@"Valor investiddo menor que 0");
            }

            var produto = await ConverteDtoParaObj(item);
            produto.Cliente = cliente;
            return await Add(produto);
        }

        public async Task Editar(ProdutoDto item)
        {
            if (!item.DataResgate.HasValue)
            {
                throw new BusinessException(@"Data de resgate não foi informada");
            }

            if (DateTime.Compare(item.DataResgate.Value, item.DataInvestimento)< 0)
            {
                throw new BusinessException(@"Data de resgate inferior a data de investimento");
            }

            //var produto = await ConverteDtoParaObj(item);
            var produto = await GetById(item.Id);
            var tipoProduto = await _tipoProdutoBusiness.GetById(produto.IdTipoProduto);
            produto.ValorAtual = CalculaValorAtual(produto.ValorInvestido.Value, tipoProduto.Rentabilidade, produto.DataInvestimento, item.DataResgate.Value);
            produto.DataResgate = item.DataResgate;
            produto.ValorResgatado = item.ValorResgatado;
            produto.IdSituacaoProduto = (int)SituacaoProdutoEnum.Movimentado;
            var strategy = DefineIrFactory.create(produto);
            produto.ValorImposto = strategy.CalculaImposto();
            await Update(produto);
        }

        public decimal? CalculaValorAtual(decimal valorInvestido, decimal rentabilidade, DateTime dataInvestimento, DateTime hoje)
        {
            var valorAcumulado = 0m;
            var valorFinal = valorInvestido;
            var totalDiasAplicacao = Convert.ToInt32(hoje.Subtract(dataInvestimento).TotalDays);
            for (int i = 1; i < totalDiasAplicacao; i++)
            {
                var valorRendimentoPorDia = valorFinal * ((rentabilidade - 1m) / 30m) + 1m;
                valorAcumulado += valorRendimentoPorDia;
                if(i%30 == 0)
                {
                    valorFinal += valorAcumulado;
                    valorAcumulado = 0;
                }
            }
            return valorFinal += valorAcumulado;
        }

        public async Task<ProdutoDto> GetItemById(int id)
        {
            var produto = await GetById(id);
            var tipoProduto = await _tipoProdutoBusiness.GetById(produto.IdTipoProduto);
            produto.ValorAtual = CalculaValorAtual(produto.ValorInvestido.Value,tipoProduto.Rentabilidade,produto.DataInvestimento, DateTime.Now);
            return new ProdutoDto(produto);
        }

        public async Task<List<ProdutoDto>> GetListGrid()
        {
            List<Produto> produtoLista = await GetAllAsync();
            var retorno = new List<ProdutoDto>();
            foreach (var item in produtoLista)
            {
                var itemView = new ProdutoDto(item);
                retorno.Add(itemView);
            }
            return retorno;
        }
        private async Task<Produto> ConverteDtoParaObj(ProdutoDto item)
        {
            try
            {
                var retorno = new Produto()
                {
                    Id = item.Id,
                    ValorInvestido = item.ValorInvestido,
                    ValorAtual = item.ValorAtual,
                    ValorResgatado = item.ValorResgatado,
                    DataInvestimento = item.DataInvestimento,
                    DataResgate = item.DataResgate,
                    TipoProduto = await _tipoProdutoBusiness.GetById((int)item.IdTipoProduto),
                    SituacaoProduto = await _situacaoProdutoBusiness.GetById((int)item.IdSituacaoProduto)
                };
                return retorno;
            }
            catch(Exception e)
            {
                throw e;
            }

        }
    }
}
