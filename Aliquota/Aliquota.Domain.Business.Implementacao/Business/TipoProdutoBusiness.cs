using Aliquota.Domain.Business.IBusiness;
using Aliquota.Domain.Business.Implementacao.Base;
using Aliquota.Domain.Entities.DTO;
using Aliquota.Domain.Entities.Entidades;
using Aliquota.Domain.Repository.IRepositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.Business.Implementacao.Business
{
    public class TipoProdutoBusiness : BusinessCrudBase<TipoProduto>, ITipoProdutoBusiness
    {
        public TipoProdutoBusiness(ITipoProdutoRepositorio tipoProdutoRepositorio)
            : base()
        {
            _repository = tipoProdutoRepositorio;
        }

        public async Task Criar(TipoProdutoDto item)
        {
            await Add(ConverteDtoParaObj(item));
        }

        public async Task Editar(TipoProdutoDto item)
        {
            await Update(ConverteDtoParaObj(item));
        }

        public async Task<TipoProdutoDto> GetItemById(int id)
        {
            return new TipoProdutoDto(await GetById(id));
        }

        public async Task<List<TipoProdutoDto>> GetListGrid()
        {
            List<TipoProduto> tipoProdutoLista = await GetAllAsync(); 
            var retorno = new List<TipoProdutoDto>();
            foreach (var item in tipoProdutoLista)
            {
                var itemView = new TipoProdutoDto(item);
                retorno.Add(itemView);
            }
            return retorno;
        }
        private TipoProduto ConverteDtoParaObj(TipoProdutoDto item)
        {
            var rentabilidade = 1 + (item.Rentabilidade / 100m);
            return new TipoProduto() { Id = item.Id, NomeTipoProduto = item.NomeTipoProduto, Rentabilidade = rentabilidade };
        }
    }
}
