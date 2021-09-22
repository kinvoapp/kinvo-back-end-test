using System;
using System.Linq.Expressions;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Queries
{
    public static class CreateQueriesInfos
    {
        public static Expression<Func<Client, bool>> ClientExists(string document)
        {
            return x => x.Document == document;
        }
        public static Expression<Func<Product, bool>> ProductExists(string productName)
        {
            return x => x.Title == productName; //trocar por id
        }
        public static Expression<Func<Product, bool>> GetProductsInfo(string title)
        {
            return x => x.Title == title;
        }
        public static Expression<Func<Client, bool>> GetClientInfo(string document)
        {
            return x => x.Document == document;
        }
        public static Expression<Func<Order, bool>> GetOrderInfo(string order)
        {
            return x => x.Document == order;
            //return x => x.Client.User == user && x.Client.Document == document;
        }
        public static Expression<Func<Order, bool>> GetValue(double price)
        {
            return x => x.TaxValue == price;
        }
    }
}
