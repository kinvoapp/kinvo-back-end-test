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
            return false;
        }

        public Client GetById(Guid id)
        {
            return null;
        }

        public Product GetByProductId(Guid id)
        {
            return null;
        }

        public Order GetOrderById(Order order)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Order GetTax(Product product)
        {
            throw new NotImplementedException();
        }

        public Order ReturnIncomeTax(Order order)
        {
            throw new NotImplementedException();
        }

        public Order ReturnIncomeTax(double productTax)
        {
            throw new NotImplementedException();
        }

        public void Save(Client client)
        {

        }

        public void SaveOrder(Order order)
        {

        }

        public void SaveProduct(Product product)
        {

        }

        IEnumerable<Client> IProductRepository.GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Product> IProductRepository.GetByProductId(Guid id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Order> IProductRepository.GetOrderById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
