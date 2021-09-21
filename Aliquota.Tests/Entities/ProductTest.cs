using System;
using Aliquota.Domain.Entities;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class ProductTest
    {
        [Fact(DisplayName = "Teste Criação de Produto e Cliente")]

        public void CreateProduct()
        {
            Product _product = new Product("EGIE3", 250, DateTime.Now, DateTime.Now.AddYears(1));
            Client _client = new Client("Kaoe", "00000000000");
            Order order = new Order(_client);


            var expected = true;

            order.AddProducts(_product);


            Assert.Equal(expected, _product.Valid);
        }
        [Fact(DisplayName = "Teste de data de finalização do Produto menor que data de criação - Domain Notification")]
        public void ErrorProductDateNotification()
        {
            Product _product = new Product("EGIE3", 250, DateTime.Now.AddDays(5), DateTime.Now);
            Client _client = new Client("Kaoe", "00000000000");
            Order order = new Order(_client);


            var expected = true;

            order.AddProducts(_product);

            Assert.Equal(expected, _product.Invalid);
        }
        [Fact(DisplayName = "Teste de valor zero do Produto - Domain Notification")]
        public void ErrorProductPriceNotification()
        {
            Product _product = new Product("EGIE3", 0, DateTime.Now, DateTime.Now.AddYears(1));
            Client _client = new Client("Kaoe", "00000000000");
            Order order = new Order(_client);


            var expected = true;

            order.AddProducts(_product);

            Assert.Equal(expected, _product.Invalid);
        }
        [Fact(DisplayName = "Teste de nome do Produto - Domain Notification")]
        public void ErrorProductNameNotification()
        {
            Product _product = new Product("EGIE3", 250, DateTime.Now, DateTime.Now.AddYears(1));
            Client _client = new Client("K", "00000000000");
            Order order = new Order(_client);


            var expected = true;

            order.AddProducts(_product);

            Assert.Equal(expected, _client.Invalid);
            Assert.Equal(expected, _product.Valid);
        }
        [Fact(DisplayName = "Teste de data do Produto(Data correta) - Domain Notification")]
        public void ErrorProductDateCorrectNotification()

        {
            Product _product = new Product("EGIE3", 250, DateTime.Now, DateTime.Now.AddYears(1));
            Client _client = new Client("Kaoe", "00000000000");
            Order order = new Order(_client);


            var expected = true;

            order.AddProducts(_product);

            Assert.Equal(expected, _product.Valid);
        }
    }
}
