using System.Linq.Expressions;
using FinancialProduct.Domain.Entities;

namespace FinancialProduct.Domain.Queries;

    public static class ProductQuery
    {
        public static Expression<Func<Product, bool>> GetAllQuery(string user)
        {
            return x => x.User == user;
        }

        public static Expression<Func<Product, bool>> GetAllDone(string user)
        {
            return x => x.User == user && x.Drawee == true;
        }     
       
    }
