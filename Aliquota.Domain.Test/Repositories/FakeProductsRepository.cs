using System;
using System.Collections.Generic;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Repositories;

namespace Aliquota.Domain.Test.Repositories
{
    //Nosso código deve depender de abstração e nunca de implementação 
    public class FakeProductsRepository : IProductRepository
    {
        private Product Product;
        private IList<Product> _products;
        public FakeProductsRepository()
        {

        }
        public void Create(Product product)
        {

        }

        public IEnumerable<Product> GetByDate(string title, DateTime date)
        {
            //throw new NotImplementedException();
            return null;
        }

        public Product GetById(Guid id, string title)
        {
            //throw new NotImplementedException();
            return new Product("ABEV3", 300, DateTime.Now, DateTime.Now);
        }

        public IEnumerable<Product> GetPrices(double price)
        {
            //throw new NotImplementedException();
            return null;
        }

        public Product GetProduct(Guid id, string title, double price)
        {
            //throw new NotImplementedException();
            return new Product("ABEV3", 300, DateTime.Now, DateTime.Now);
        }

        public IEnumerable<Product> GetProducts(string title)
        {
            //throw new NotImplementedException();
            return null;
        }

        public Product GetTaxValue(double value)
        {
            return new Product("ABEV3", value, DateTime.Now, DateTime.Now);
        }

        public void Save(Product product)
        {

        }
    }
}
