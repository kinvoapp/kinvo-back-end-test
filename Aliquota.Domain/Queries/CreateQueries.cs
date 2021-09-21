using System;
using System.Linq.Expressions;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Queries
{
    public static class CreateQueries
    {
        public static Expression<Func<Product, bool>> GetProductsInfo(string title, double price)
        {
            return x => x.Title == title && x.Price == price;
        }
        public static Expression<Func<Client, bool>> GetClientInfo(string user, string document)
        {
            return x => x.User == user && x.Document == document;
        }
        public static Expression<Func<Order, bool>> GetOrderInfo(Client client)
        {
            return x => x.Client == client;
        }
    }
}
