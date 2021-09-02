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

        public void Criar(TipoProdutoDto item)
        {
            Add(ConverteDtoParaObj(item));
        }

        public void Editar(TipoProdutoDto item)
        {
            Update(ConverteDtoParaObj(item));
        }

        public async Task<TipoProdutoDto> GetItemById(int id)
        {
            return new TipoProdutoDto(await GetById(id));
        }

        public async Task<List<TipoProdutoDto>> GetListGrid()
        {
            List<TipoProduto> tipoProdutoLista = await GetAll(); 
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
            return new TipoProduto() { Id = item.Id, NomeTipoProduto = item.NomeTipoProduto, Rentabilidade = item.Rentabilidade };
        }
    }
}
