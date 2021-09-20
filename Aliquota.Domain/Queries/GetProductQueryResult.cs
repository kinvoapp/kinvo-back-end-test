using System;
using System.Linq.Expressions;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Queries
{
    public static class GetProductQueryResult
    {
        public static Expression<Func<Product, bool>> GetProducts(string title)
        {
            return x => x.Title == title;
        }

        public static Expression<Func<Product, bool>> GetPrices(double price)
        {
            return x => x.Price == price;
        }
        public static Expression<Func<Product, bool>> GetById(Guid id, string title)
        {
            return x => x.Id == id &&
            x.Title == title;
        }
        public static Expression<Func<Product, bool>> GetByDate(string title, DateTime date)
        {
            return x =>
            x.Title == title &&
            x.ApplicationDate == date;
        }
        public static Expression<Func<Product, bool>> GetTaxValue(double value)
        {
            return x => x.Value == value;
        }
    }
}
