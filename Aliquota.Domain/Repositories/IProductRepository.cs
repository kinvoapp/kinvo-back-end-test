using System;
using System.Collections.Generic;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Repositories
{
    //Abstração
    public interface IProductRepository
    {
        void Create(Product product);
        void Save(Product product);
        double GetTaxValue(double value);
        Product GetProduct(Guid id, string title, double price);
        IEnumerable<Product> GetProducts(string title);
        IEnumerable<Product> GetPrices(double price);
        Product GetById(Guid id, string title);
        IEnumerable<Product> GetByDate(string title, DateTime date);
    }
}
