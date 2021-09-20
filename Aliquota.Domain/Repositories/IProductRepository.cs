using System;
using System.Collections.Generic;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Repositories
{
    public interface IProductRepository
    {
        void Create(Product product);
        IncomeTaxValue GetApplicationTaxValue(Product product);
        Product GetProduct(Guid id, string title, double price);
        IEnumerable<Product> GetProducts(string title);
        IEnumerable<Product> GetPrices(double price);
        Product GetById(Guid id, string title);
        IEnumerable<Product> GetByDate(string title, DateTime date);
    }
}
