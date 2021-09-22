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
            Client _client = new Client("Kaoe", "00000000000");
            Order order = new Order(_client.User, _client.Document);


            // order.SaveOrder(_product); quem salva é o repositorio
            var expected = true;

            order.AddProducts(_product);

            Assert.Equal(expected, _product.Valid);
        }
        [Fact(DisplayName = "Teste Criação de Produto, Cliente e Pegar Taxa")]
        public void CreateProductAndClientAndProductAndGetRescue()
        {
            Product produto = new Product("EGIE3", 250, DateTime.Now, DateTime.Now.AddYears(1));
            Client _client = new Client("Kaoe", "00000000000");
            Order order = new Order(_client.User, _client.Document);


            var expected = true;

            order.AddProducts(produto);
            order.ReturnProductTax(produto);

            Assert.Equal(expected, _client.Valid);
        }
        [Fact(DisplayName = "Teste de Nome De Cliente Nulo - Domain Notification")]
        public void NullClientNameNotification()
        {
            Product _product = new Product("EGIE3", 250, DateTime.Now, DateTime.Now.AddYears(1));
            Client _client = new Client(null, null);
            Order order = new Order(_client.User, _client.Document);


            var expected = true;

            order.AddProducts(_product);
            order.ReturnProductTax(_product);

            Assert.Equal(expected, _client.Invalid);
        }

        [Fact(DisplayName = "Teste de Cliente Nome minimo 3 Caractere - Domain Notification")]
        public void ShortClientNameNotification()
        {
            Product _product = new Product("EGIE3", 250, DateTime.Now, DateTime.Now.AddYears(1));
            Client _client = new Client("K", "00000000000");
            Order order = new Order(_client.User, _client.Document);


            var expected = true;

            order.AddProducts(_product);
            order.ReturnProductTax(_product);

            Assert.Equal(expected, _client.Invalid);

        }
        [Fact(DisplayName = "Teste de Cliente CPF invalido - Domain Notification")]
        public void CPFInvalidNotification()
        {
            Product _product = new Product("EGIE3", 250, DateTime.Now, DateTime.Now.AddYears(1));
            Client _client = new Client("Kaoe", "00000");
            Order order = new Order(_client.User, _client.Document);


            var expected = true;

            order.AddProducts(_product);
            order.ReturnProductTax(_product);

            Assert.Equal(expected, _client.Invalid);
        }
    }
}
