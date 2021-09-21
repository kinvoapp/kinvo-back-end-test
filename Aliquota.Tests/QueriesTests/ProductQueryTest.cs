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
        private IList<Client> _clients;
        private Client _client1;
        private Client _client2;
        private Client _client3;
        private Product _product1;
        private Product _product2;
        private Product _product3;
        private Product _product4;
        private IList<Product> _product;
        private IList<Order> _order;
        public ProductQueryTest()
        {
            _clients = new List<Client>();
            _product = new List<Product>();
            _order = new List<Order>();

            _product1 = new Product("ABDC1", 20.5, DateTime.Now.Date, DateTime.Now.AddMonths(2).Date);
            _product2 = new Product("ABDC2", 25, DateTime.Now.Date, DateTime.Now.AddMonths(5).Date);
            _product3 = new Product("ABDC3", 38, DateTime.Now.Date, DateTime.Now.AddMonths(2).Date);
            _product4 = new Product("ABDC3", 38, DateTime.Now.Date, DateTime.Now.AddMonths(2).Date);

            _client1 = new Client("Kaoe", "00000000000");
            _client2 = new Client("Joao", "00000000000");
            _client3 = new Client("Kaoe", "00000000000");

            _clients.Add(_client1);
            _clients.Add(_client2);
            _clients.Add(_client3);


            _product.Add(_product1);
            _product.Add(_product2);
            _product.Add(_product3);
            _product.Add(_product4);

            _order.Add(new Order(_client1.User, _client1.Document));
        }

        [Fact]

        public void GetClientInfoQuerySuccess()
        {
            var result = _clients.AsQueryable().Where(CreateQueriesInfos.GetClientInfo(_client3.Id));

            Assert.Equal(1, result.Count());
        }
        [Fact]
        public void GetProductInfoQuerySuccess()
        {
            var result = _product.AsQueryable().Where(CreateQueriesInfos.GetProductsInfo(_product3.Id));

            Assert.Equal(1, result.Count());
        }
        // [Fact]
        // public void GetProductTaxQuerySuccess()
        // {
        //     var result = _product.AsQueryable().Where(CreateQueriesInfos.GetValue(25.05));

        //     Assert.Equal(1, result.Contains(_product1.TaxValue));
        // }
    }
}
