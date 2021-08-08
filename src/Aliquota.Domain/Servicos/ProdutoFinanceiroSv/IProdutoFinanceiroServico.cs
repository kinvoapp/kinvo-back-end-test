using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.Servicos.ProdutoFinanceiroSv
{
    public interface IProdutoFinanceiroServico
    {
        Task<IEnumerable<ProdutoFinanceiro>> BuscarTodos();
        Task CadastraProdutoFinanceiro(ProdutoFinanceiro produtoFinanceiro);
        Task<ProdutoFinanceiro> BuscaProdutoFinanceiroPor(Guid id);
        Task DeletaProdutoFinanceiro(ProdutoFinanceiro produtoFinanceiro);
        Task ResgataProdutoFinanceiro(string dataResgate, ProdutoFinanceiro produtoFinanceiro);
    }
}
