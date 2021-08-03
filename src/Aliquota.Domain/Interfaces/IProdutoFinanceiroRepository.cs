using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aliquota.Core.Data;
using Aliquota.Domain.Models;

namespace Aliquota.Domain.Interfaces
{
    public interface IProdutoFinanceiroRepository : IRepository<ProdutoFinanceiro>
    {
        Task<ProdutoFinanceiro> ObterPeloId(Guid id);
        Task Adicionar(ProdutoFinanceiro produtoFinanceiro);
        Task<List<ProdutoFinanceiro>> ObterTodos();
    }
}