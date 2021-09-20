using System;
using Aliquota.Domain.Entities;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class ClientTest
    {
        //Red, Green Refactor
        //Arrange, Act, Assert 
        [Fact(DisplayName = "Teste Criação de Produto e Cliente")]

        public void CreateProductAndClientAndProduct()
        {
            Product _product = new Product("EGIE3", 250, DateTime.Now, DateTime.Now.AddYears(1));
            Client _client = new Client("Kaoe");
            var expected = true;
            _client.AddProduct(_product);
            Assert.Equal(expected, _client.Valid);
            Assert.Equal(expected, _product.Valid);
        }
        [Fact(DisplayName = "Teste Criação de Produto, Cliente e Pegar Taxa")]
        public void CreateProductAndClientAndProductAndGetRescue()
        {
            Product _product = new Product("EGIE3", 300, DateTime.Now, DateTime.Now.AddMonths(3));
            Client _client = new Client("Kaoe");
            var expected = true;
            _client.Rescue(_product); //retorna valor da taxa do produto
            Assert.Equal(expected, _client.Valid);
            Assert.Equal(expected, _product.Valid);
        }
        [Fact(DisplayName = "Teste de Nome De Cliente Nulo - Domain Notification")]
        public void NullClientNameNotification()
        {
            Product _product = new Product("EGIE3", 300, DateTime.Now, DateTime.Now.AddMonths(3));
            Client _client = new Client(null); //não pode ser nulo !!
            var expected = false;
            _client.Rescue(_product);
            Assert.Equal(expected, _client.Valid);
        }
        [Fact(DisplayName = "Teste de Cliente Nome minimo 3 Caractere - Domain Notification")]
        public void ShortClientNameNotification()
        {
            Product _product = new Product("EGIE3", 300, DateTime.Now, DateTime.Now.AddMonths(3));
            Client _client = new Client("a");
            var expected = false;
            _client.Rescue(_product);
            Assert.Equal(expected, _client.Valid);
        }
    }
}
