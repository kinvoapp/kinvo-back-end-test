using System;
using System.Collections.Generic;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Repositories
{
    //Abstração
    public interface IProductRepository
    {
        void Create(Product product);
        Product GetTaxValue(double value);
        Product GetProduct(Guid id, string title, double price);
        IEnumerable<Product> GetProducts(string title);
        IEnumerable<Product> GetPrices(double price);
        Product GetById(Guid id, string title);
        IEnumerable<Product> GetByDate(string title, DateTime date);
        //IEnumerable é usado para que uma vez fora do banco de dados ninguém manipule a lista
    }
}
