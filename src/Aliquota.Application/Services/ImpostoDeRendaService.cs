using Aliquota.Application.Interfaces;
using Aliquota.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Aliquota.Application.Services
{
    public class ImpostoDeRendaService : IImpostoDeRendaService
    {
        private ICalculoDoImpostoDeRendaService _calculoDoImpostoDeRendaService;

        public ImpostoDeRendaService(ICalculoDoImpostoDeRendaService calculoDoImpostoDeRendaService)
        {
            _calculoDoImpostoDeRendaService = calculoDoImpostoDeRendaService;
        }

        public async Task<double> Calcular(Guid produtoFinanceiroId)
        {
            return await _calculoDoImpostoDeRendaService.Calcular(produtoFinanceiroId);
        }
    }
}
