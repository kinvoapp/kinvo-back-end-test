using System;
using System.Collections.Generic;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Repositories;

namespace Aliquota.Domain.Test.Repositories
{
    //Nosso código deve depender de abstração e nunca de implementação 
    public class FakeProductsRepository : IProductRepository
    {
        public bool ClientExist(string document)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetById(string document)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetByProductId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetClient(string document)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrder(string order)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrderById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProduct(string title)
        {
            throw new NotImplementedException();
        }

        public bool ProductExist(string productName)
        {
            throw new NotImplementedException();
        }

        public Order ReturnIncomeTax(double productTax)
        {
            throw new NotImplementedException();
        }

        public void Save(Client client)
        {
            throw new NotImplementedException();
        }

        public void SaveOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void SaveProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
