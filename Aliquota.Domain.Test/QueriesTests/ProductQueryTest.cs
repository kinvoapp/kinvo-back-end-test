using System;
using System.Collections.Generic;
using System.Linq;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Queries;
using Xunit;

namespace Aliquota.Domain.Test.Queries
{
    public class ProductQueryTest
    {
        private List<Product> _products;
        public ProductQueryTest()
        {
            _products = new List<Product>();
            _products.Add(new Product("ITUB3", 25.86, DateTime.Now, DateTime.Now.AddMonths(6)));
            _products.Add(new Product("ITSA4", 42.50, DateTime.Now.AddDays(5), DateTime.Now.AddMonths(2)));
            _products.Add(new Product("BBDC4", 10.15, DateTime.Now, DateTime.Now.AddYears(1)));
            _products.Add(new Product("ITSA4", 42.50, DateTime.Now, DateTime.Now.AddMonths(2)));
            _products.Add(new Product("BBSE3", 5.00, DateTime.Now, DateTime.Now.AddDays(6)));
            _products.Add(new Product("TAEE4", 85.26, DateTime.Now, DateTime.Now.AddMonths(2)));
            _products.Add(new Product("ITSA4", 42.50, DateTime.Now, DateTime.Now.AddMonths(2)));
            _products.Add(new Product("BBAS3", 15.85, DateTime.Now, DateTime.Now.AddMonths(9)));
            _products.Add(new Product("ITSA4", 42.50, DateTime.Now, DateTime.Now.AddMonths(2)));
        }
        [Fact(DisplayName = "Teste Para retornar um produto especifico do usuario pelo Titulo")]
        public void ReturnProductFromUser()
        {
            var result = _products.AsQueryable().Where(GetProductQueryResult.GetProducts("ITSA4"));
            Assert.Equal(4, result.Count());
        }
        [Fact(DisplayName = "Teste Para retornar um produto especifico do usuario pelo preço")]
        public void ReturnPriceFromUser()
        {
            var result = _products.AsQueryable().Where(GetProductQueryResult.GetPrices(10.15));
            Assert.Equal(1, result.Count());
        }
        [Fact(DisplayName = "Teste Para retornar um produto especifico do usuario pela data")]
        public void ReturnDateFromUser()
        {
            var result = _products.AsQueryable().Where(GetProductQueryResult.GetByDate("ITSA4", DateTime.Now));
            Assert.Equal(4, result.Count()); //verificar bug do teste
        }
    }
}
