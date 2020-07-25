using Aliquota.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Application.Interface
{
    public interface IAplicacaoFinanceiraAppService
    {
        Task<AplicacaoFinanceira> Handle(Cliente cliente, decimal valor, ProdutoFinanceiro produto);
    }
}
