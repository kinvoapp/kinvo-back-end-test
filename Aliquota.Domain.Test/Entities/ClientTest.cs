using System;
using Aliquota.Domain.Entities;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class ClientTest
    {
        [Fact(DisplayName = "Teste Criação de Produto e Cliente")]

        public void CreateProductAndClientAndProduct()
        {
            Product _product = new Product("EGIE3", 250, DateTime.Now, DateTime.Now.AddYears(1));
            Client _client = new Client("Kaoe");
            var expected = true;
            _client.AddProduct(_product);
            Assert.Equal(expected, _client.Valid);
        }
        [Fact(DisplayName = "Teste Criação de Produto, Cliente e Pegar Taxa")]
        public void CreateProductAndClientAndProductAndGetRescue()
        {
            Product _product = new Product("EGIE3", 300, DateTime.Now, DateTime.Now.AddMonths(3));
            Client _client = new Client("Kaoe");
            var expected = true;
            _client.Rescue(_product);
            Assert.Equal(expected, _client.Valid);
        }
        [Fact(DisplayName = "Teste de Nome Nulo - Error Notification")]
        public void NullNameNotification()
        {
            Product _product = new Product("EGIE3", 300, DateTime.Now, DateTime.Now.AddMonths(3));
            Client _client = new Client(null);
            var expected = true;
            _client.Rescue(_product);
            Assert.Equal(expected, _client.Valid);
        }
        [Fact(DisplayName = "Teste de Nome 3 Caractere - Error Notification")]
        public void ShortNameNotification()
        {
            Product _product = new Product("EGIE3", 300, DateTime.Now, DateTime.Now.AddMonths(3));
            Client _client = new Client("a");
            var expected = true;
            _client.Rescue(_product);
            Assert.Equal(expected, _client.Valid);
        }
        [Fact(DisplayName = "Teste de data de finalização menor que data de criação - Error Notification")]
        public void ErrorDateNotification()
        {
            Product _product = new Product("EGIE3", 300, DateTime.Now.AddDays(5), DateTime.Now);
            Client _client = new Client("");
            var expected = true;
            _client.Rescue(_product);
            Assert.Equal(expected, _client.Valid);
            //codigo correto
        }
    }
}
