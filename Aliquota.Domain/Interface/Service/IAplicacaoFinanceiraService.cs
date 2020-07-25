using Aliquota.Domain.Entity;
using System;
using System.Threading.Tasks;

namespace Aliquota.Domain.Interface
{
    public interface IAplicacaoFinanceiraService : IServiceBase<AplicacaoFinanceira>
    {
        Task<decimal> GerarResgateTotal(Guid aplicacaoId);
        Task<AplicacaoFinanceira> Aplicar(Cliente cliente, decimal valor, ProdutoFinanceiro produto);

    }
}
