using Aliquota.Domain.Entities.DTO;
using Aliquota.Domain.Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Business.IBusiness
{
    public interface IProdutoBusiness : IBusinessCrudBase<Produto>
    {
        Task<List<ProdutoDto>> GetListGrid();
        void Criar(ProdutoDto item);
        Task<ProdutoDto> GetItemById(int id);
        void Editar(ProdutoDto item);
    }
}
