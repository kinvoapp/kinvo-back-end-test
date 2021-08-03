using System;
using System.Threading.Tasks;

namespace Aliquota.Application.Interfaces
{
    public interface IImpostoDeRendaService
    {
        Task<double> Calcular(Guid produtoFinanceiroId);
    }
}