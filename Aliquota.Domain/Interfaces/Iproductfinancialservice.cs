using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Interfaces
{
    public interface Iproductfinancialservice
    {
        void CreateProductFinancial(productfinancial productfinancial);
        productfinancial SearchProductFinancial(productfinancial productfinancial);
    }
}
