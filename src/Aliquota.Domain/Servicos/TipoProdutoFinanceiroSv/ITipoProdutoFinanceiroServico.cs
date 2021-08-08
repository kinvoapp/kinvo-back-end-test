using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.Servicos.TipoProdutoFinanceiroSv
{
    public interface ITipoProdutoFinanceiroServico
    {
        Task<IEnumerable<TipoProdutoFinanceiro>> BuscarTodos();
        Task CadastraTipoProdutoFinanceiro(TipoProdutoFinanceiro tipoProdutoFinanceiro);
        Task<TipoProdutoFinanceiro> BuscaTipoProdutoFinanceiroPor(Guid id);
        Task DeletaTipoProdutoFinanceiro(TipoProdutoFinanceiro tipoProdutoFinanceiro);
        Task AlteraTipoProdutoServico(TipoProdutoFinanceiro tipoProdutoFinanceiro);
    }
}
