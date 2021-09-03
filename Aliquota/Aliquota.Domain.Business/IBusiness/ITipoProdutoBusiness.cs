using Aliquota.Domain.Entities.DTO;
using Aliquota.Domain.Entities.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.Business.IBusiness
{
    public interface ITipoProdutoBusiness : IBusinessCrudBase<TipoProduto>
    {
        Task<List<TipoProdutoDto>> GetListGrid();
        Task Criar(TipoProdutoDto item);
        Task<TipoProdutoDto> GetItemById(int id);
        Task Editar(TipoProdutoDto item);
    }
}
