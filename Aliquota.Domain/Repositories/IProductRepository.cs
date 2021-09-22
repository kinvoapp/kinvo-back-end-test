using System;
using System.Collections.Generic;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Queries;

namespace Aliquota.Domain.Repositories
{
    //Abstração
    public interface IProductRepository
    {
        //IEnumerable é usado para que uma vez fora do banco de dados ninguém manipule a lista
        bool ClientExist(string document);
        bool ProductExist(string productName);
        void Save(Client client);
        void SaveOrder(Order order);
        void SaveProduct(Product product);

        Client GetClient(string document);
        Product GetProduct(string title);
        Order GetOrder(string userDocument);
        Order ReturnIncomeTax(double productTax);
    }
}
