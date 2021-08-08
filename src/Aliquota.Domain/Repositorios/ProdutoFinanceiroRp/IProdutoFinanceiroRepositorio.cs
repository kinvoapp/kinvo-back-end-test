using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.Repositorios.ProdutoFinanceiroRp
{
    public interface IProdutoFinanceiroRepositorio
    {
        Task<IEnumerable<ProdutoFinanceiro>> BuscarTodos();
        Task SalvaProdutoFinanceiro(ProdutoFinanceiro produtoFinanceiro);
        Task<ProdutoFinanceiro> BuscaProdutoFinanceiroPor(Guid id);
        Task DeletaProdutoFinanceiro(ProdutoFinanceiro produtoFinanceiro);
        Task AtualizaProdutoFinanceiro(ProdutoFinanceiro produtoFinanceiro);
    }
}
