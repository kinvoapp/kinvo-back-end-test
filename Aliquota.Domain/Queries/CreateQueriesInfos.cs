using System;
using System.Linq.Expressions;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Queries
{
    public static class CreateQueriesInfos
    {
        public static Expression<Func<Product, bool>> GetProductsInfo(Guid id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<Client, bool>> GetClientInfo(Guid id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<Order, bool>> GetOrderInfo(Guid id)
        {
            return x => x.Id == id;
            //return x => x.Client.User == user && x.Client.Document == document;
        }
        public static Expression<Func<Order, bool>> GetValue(double price)
        {
            //return x => x.TaxValue == order;
            //resolver
            //retornar valor do produto final na query
            return x => x.TaxValue == price;
        }
    }
}
