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
        Task<Produto> Criar(ProdutoDto item, Cliente cliente);
        Task<ProdutoDto> GetItemById(int id);
        Task Editar(ProdutoDto item);
        decimal? CalculaValorAtual(decimal valorInvestido, decimal rentabilidade, DateTime dataInvestimento, DateTime hoje);


    }
}
