using Aliquota.Application.Interface;
using Aliquota.Domain.Entity;
using Aliquota.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Application.Service
{
    public class AplicacaoFinanceiraAppService : AppServiceBase, IAplicacaoFinanceiraAppService
    {
        private readonly IAplicacaoFinanceiraService Service;
        public AplicacaoFinanceiraAppService(IAplicacaoFinanceiraService service)
        {
            Service = service;
        }

        public async Task<AplicacaoFinanceira> Handle(Cliente cliente, decimal valor, ProdutoFinanceiro produto) => await Service.Aplicar(cliente, valor, produto);
    }
}
