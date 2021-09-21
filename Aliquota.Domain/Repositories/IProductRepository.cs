using System;
using System.Collections.Generic;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Repositories
{
    //Abstração
    public interface IProductRepository
    {
        //IEnumerable é usado para que uma vez fora do banco de dados ninguém manipule a lista
        bool ClientExist(string document);
        void Save(Client client);
        void SaveOrder(Order order);
        void SaveProduct(Product product);

        IEnumerable<Client> GetById(Guid id);
        IEnumerable<Product> GetByProductId(Guid id);
        IEnumerable<Order> GetOrderById(Guid id);
        Order ReturnIncomeTax(double productTax);


    }
}
