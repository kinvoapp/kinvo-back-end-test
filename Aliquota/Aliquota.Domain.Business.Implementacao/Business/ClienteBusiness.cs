using Aliquota.Domain.Business.IBusiness;
using Aliquota.Domain.Business.Implementacao.Base;
using Aliquota.Domain.Entities.DTO;
using Aliquota.Domain.Entities.Entidades;
using Aliquota.Domain.Repository.IRepositorios;
using Aliquota.Domin.Util.Enum;
using Aliquota.Domin.Util.Excecoes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Business.Implementacao.Business
{
    public class ClienteBusiness : BusinessCrudBase<Cliente>, IClienteBusiness
    {
        private readonly IProdutoBusiness _produtoBusiness;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly ISituacaoProdutoRepositorio _situacaoProdutoRepositorio;
        public ClienteBusiness(IClienteRepositorio clienteRepository, IProdutoBusiness produtoBusiness, ISituacaoProdutoRepositorio situacaoProdutoRepositorio)
            : base()
        {
            _repository = clienteRepository;
            _produtoBusiness = produtoBusiness;
            _clienteRepositorio = clienteRepository;
            _situacaoProdutoRepositorio = situacaoProdutoRepositorio;
        }

        public async Task CadastrarProduto(ProdutoDto produto)
        {
            var cliente = await _repository.GetById(produto.IdCliente);
            produto.Id = 0;
            await _produtoBusiness.Criar(produto, cliente);
        }

        public async Task MovimentarProduto(ProdutoDto produto)
        {
            await _produtoBusiness.Editar(produto);
        }

        public async Task Criar(ClienteDto item)
        {
           await Add(ConverteDtoParaObj(item));
        }

        public async Task Editar(ClienteDto item)
        {
           await Update(ConverteDtoParaObj(item));
        }

        public async Task<ClienteDto> GetItemById(int id)
        {
            var cliente = await _clienteRepositorio.GetClienteComProduto(id);
            foreach (var prod in cliente.ProdutoLista)
            {
                if (prod.IdSituacaoProduto == (int)SituacaoProdutoEnum.NaoMovimentado)
                {
                    prod.ValorAtual = _produtoBusiness.CalculaValorAtual(prod.ValorInvestido.Value, prod.TipoProduto.Rentabilidade, prod.DataInvestimento, System.DateTime.Now);
                }
                prod.SituacaoProduto = await _situacaoProdutoRepositorio.GetById(prod.IdSituacaoProduto);
            }
            return new ClienteDto(cliente);
        }

        public async Task<List<ClienteDto>> GetListGrid()
        {
            List<Cliente> clienteLista = await GetAllAsync();
            var retorno = new List<ClienteDto>();
            foreach (var item in clienteLista)
            {
                var itemView = new ClienteDto(item);
                retorno.Add(itemView);
            }
            return retorno;
        }


        private Cliente ConverteDtoParaObj(ClienteDto item)
        {
            return new Cliente() { Id = item.Id, NomeCliente = item.NomeCliente};
        }
    }
}
