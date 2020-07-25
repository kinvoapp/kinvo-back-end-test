using Aliquota.Application.Interface;
using Aliquota.Domain.Entity;
using Aliquota.Domain.Interface;
using System;
using System.Threading.Tasks;

namespace Aliquota.Application.Service
{
    public class ResgateAppService : AppServiceBase, IResgateAppService
    {
        private readonly IAplicacaoFinanceiraService Service;
        public ResgateAppService(IAplicacaoFinanceiraService service)
        {
            Service = service;
        }

        public async Task<decimal> Handle(Guid aplicacaoId) => await Service.GerarResgateTotal(aplicacaoId);
    }
}
