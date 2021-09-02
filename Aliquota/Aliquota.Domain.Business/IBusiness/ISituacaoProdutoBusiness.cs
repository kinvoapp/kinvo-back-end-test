using Aliquota.Domain.Entities.DTO;
using Aliquota.Domain.Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Business.IBusiness
{
    public interface ISituacaoProdutoBusiness : IBusinessCrudBase<SituacaoProduto>
    {
        Task<List<SituacaoProdutoDto>> GetListGrid();
        void Criar(SituacaoProdutoDto item);
        Task<SituacaoProdutoDto> GetItemById(int id);
        void Editar(SituacaoProdutoDto item);
    }
}
