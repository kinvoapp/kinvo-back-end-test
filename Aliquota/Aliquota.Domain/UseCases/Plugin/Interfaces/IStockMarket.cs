using Aliquota.Domain.Entities.Models;

namespace Aliquota.Domain.UseCases.Plugin.Interfaces
{
    public interface IStockMarket
    {
        public decimal GetProductValue(FinanceProduct product);
    }
}
