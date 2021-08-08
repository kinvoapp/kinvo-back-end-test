using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.Repositorios.TipoProdutoFinanceiroRp
{
    public interface ITipoProdutoFinanceiroRepositorio
    {
        Task<IEnumerable<TipoProdutoFinanceiro>> BuscarTodos();
        Task SalvaTipoProdutoFinanceiro(TipoProdutoFinanceiro tipoProdutoFinanceiro);
        Task<TipoProdutoFinanceiro> BuscaTipoProdutoFinanceiroPor(Guid id);
        Task DeletaTipoProdutoFinanceiro(TipoProdutoFinanceiro tipoProdutoFinanceiro);
        Task AtualizaTipoProdutoFinanceiro(TipoProdutoFinanceiro tipoProdutoFinanceiro);
    }
}
