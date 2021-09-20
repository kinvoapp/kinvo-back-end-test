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
            Product _product = new Product("EGIE3", 300, DateTime.Now, DateTime.Now.AddYears(1));
            Client _client = new Client("Kaoe");
            var expected = true;
            _client.AddProduct(_product);
            Assert.Equal(expected, _product.Valid);
        }
        [Fact(DisplayName = "Teste de data de finalização do Produto menor que data de criação - Domain Notification")]
        public void ErrorProductDateNotification()
        {
            Product _product = new Product("EGIE3", 250, DateTime.Now.AddDays(5), DateTime.Now);
            Client _client = new Client("Kaoe");
            var expected = false;
            _client.Rescue(_product);
            Assert.Equal(expected, _product.Valid);
        }
        [Fact(DisplayName = "Teste de valor zero do Produto - Domain Notification")]
        public void ErrorProductPriceNotification()
        {
            Product _product = new Product("EGIE3", 0, DateTime.Now, DateTime.Now.AddDays(5));
            Client _client = new Client("Kaoe");
            var expected = false;
            _client.Rescue(_product);
            Assert.Equal(expected, _product.Valid);
        }
        [Fact(DisplayName = "Teste de nome do Produto - Domain Notification")]
        public void ErrorProductNameNotification()
        {
            Product _product = new Product("EGI", 5, DateTime.Now, DateTime.Now.AddDays(5));
            Client _client = new Client("Kaoe");
            var expected = false;
            _client.Rescue(_product);
            Assert.Equal(expected, _product.Valid);
        }
        [Fact(DisplayName = "Teste de data do Produto(Data correta) - Domain Notification")]
        public void ErrorProductDateCorrectNotification()
        {
            Product _product = new Product("EGIE3", 25, DateTime.Now, DateTime.Now.AddMonths(2));
            Client _client = new Client("Kaoe");
            var expected = true;
            _client.Rescue(_product);
            Assert.Equal(expected, _product.Valid);
        }
    }
}
