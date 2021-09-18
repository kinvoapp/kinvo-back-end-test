using System;
using System.Collections.Generic;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Repositories
{
    public interface IProductRepository
    {
        void Create(Product product);
        void Rescue(Product procut);
        IncomeTaxValue GetTaxValue(double price);
        IEnumerable<Product> GetAll(Product products);
        IEnumerable<Product> GetByDate(DateTime date);
    }
}
