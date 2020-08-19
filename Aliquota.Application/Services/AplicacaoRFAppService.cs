using System;
using Aliquota.Application.Interfaces;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Interfaces.Services;
using Aliquota.Domain.Services;

namespace Aliquota.Application.Services
{
    public class AplicacaoRFAppService: AppServiceBase<AplicacaoRF>, IAplicacaoRFAppService
    {
        private readonly IAplicacaoRFService _aplicacaoRFService;

        public AplicacaoRFAppService(IAplicacaoRFService aplicacaoRFService): base(aplicacaoRFService)
        {
            _aplicacaoRFService = aplicacaoRFService;
        }
    }
}