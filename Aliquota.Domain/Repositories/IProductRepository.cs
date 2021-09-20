using System;
using System.Collections.Generic;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Repositories
{
    public interface IProductRepository
    {
        void Create(Product product);
        double RescueTaxValue(IncomeTaxValue taxValue);
        void SaveProduct(Product product);
        IncomeTaxValue GetApplicationTaxValue(Product product);
    }
}
