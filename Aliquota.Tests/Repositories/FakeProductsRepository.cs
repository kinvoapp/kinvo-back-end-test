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

        public void Save(Client client)
        {

        }

        public void SaveOrder(Order order)
        {

        }

        public void SaveProduct(Product product)
        {

        }
    }
}
