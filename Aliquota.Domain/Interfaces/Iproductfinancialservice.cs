using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Interfaces
{
    public interface Iproductfinancialservice
    {
        void CreateProductFinancial(productfinancial productfinancial);
        productfinancial SearchProductFinancial(productfinancial productfinancial);
    }
}
