using Aliquota.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.Interfaces.Servicos
{
    public interface IProdutoFinanceiroServico
    {
        Task<IList<ProdutoFinanceiro>> ObterTodosAsync();

        Task<ProdutoFinanceiro> ObterPorIdAsync(Guid id);

        Task<ProdutoFinanceiro> RemoverPorIdAsync(Guid id);
    }
}