using System;
using System.Threading.Tasks;

namespace Aliquota.Domain.Interfaces
{
    public interface ICalculoDoImpostoDeRendaService
    {
        Task<double> Calcular(Guid produtoFinanceiroId);
    }
}