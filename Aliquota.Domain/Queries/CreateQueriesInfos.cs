using System;
using System.Linq.Expressions;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Queries
{
    public static class CreateQueriesInfos
    {
        //Classe estática apenas para retornar as query, não precisando instanciar elas 
        public static Expression<Func<Client, bool>> ClientExists(string document)
        {
            return x => x.Document == document;
        }
        public static Expression<Func<Product, bool>> ProductExists(string productName)
        {
            return x => x.Title == productName;
        }
        public static Expression<Func<Product, bool>> GetProductsInfo(string title)
        {
            return x => x.Title == title;
        }
        public static Expression<Func<Client, bool>> GetClientInfo(string document)
        {
            return x => x.Document == document;
        }
        public static Expression<Func<Order, bool>> GetOrderInfo(string userDocument)
        {
            return x => x.ClientDocument == userDocument;
        }
        public static Expression<Func<Order, bool>> GetValue(double value)
        {
            return x => x.TaxValue == value;
        }
    }
}
