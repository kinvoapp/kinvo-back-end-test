using Aliquota.Domain.Business.IBusiness;
using Aliquota.Domain.Business.Implementacao.Base;
using Aliquota.Domain.Entities.DTO;
using Aliquota.Domain.Entities.Entidades;
using Aliquota.Domain.Repository.IRepositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.Business.Implementacao.Business
{
    public class ProdutoBusiness : BusinessCrudBase<Produto>, IProdutoBusiness
    {
        public ProdutoBusiness(IProdutoRepositorio produtoRepository)
            : base()
        {
            _repository = produtoRepository;
        }

        public void Criar(ProdutoDto item)
        {
            Add(ConverteDtoParaObj(item));
        }

        public void Editar(ProdutoDto item)
        {
            Update(ConverteDtoParaObj(item));
        }

        public async Task<ProdutoDto> GetItemById(int id)
        {
            return new ProdutoDto(await GetById(id));
        }

        public async Task<List<ProdutoDto>> GetListGrid()
        {
            List<Produto> produtoLista = await GetAll();
            var retorno = new List<ProdutoDto>();
            foreach (var item in produtoLista)
            {
                var itemView = new ProdutoDto(item);
                retorno.Add(itemView);
            }
            return retorno;
        }
        private Produto ConverteDtoParaObj(ProdutoDto item)
        {
            return new Produto() { 
                Id = item.Id, 
                IdTipoProduto = item.IdTipoProduto, 
                IdSituacaoProduto = item.IdSituacaoProduto,
                IdCliente = item.IdCliente,
                ValorInvestido = item.ValorInvestido,
                ValorAtual = item.ValorAtual,
                ValorResgatado = item.ValorResgatado,
                DataInvestimento = item.DataInvestimento,
                DataResgate = item.DataResgate
            };
        }
    }
}
