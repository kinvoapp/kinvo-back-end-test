using Aliquota.Domain.Entities.DTO;
using Aliquota.Domain.Entities.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.Business.IBusiness
{
    public interface ITipoProdutoBusiness : IBusinessCrudBase<TipoProduto>
    {
        Task<List<TipoProdutoDto>> GetListGrid();
        void Criar(TipoProdutoDto item);
        Task<TipoProdutoDto> GetItemById(int id);
        void Editar(TipoProdutoDto item);
    }
}
