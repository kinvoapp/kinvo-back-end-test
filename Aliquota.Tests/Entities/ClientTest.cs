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
            var _product = new Product("EGIE3", 250, DateTime.Now, DateTime.Now.AddYears(1));
            var _client = new Client("Kaoe", "00000000000");
            var order = new Order(_client);


            var expected = true;

            order.AddProducts(_product);
            order.PlaceOrder();

            Assert.Equal(expected, _product.Valid);
        }
        [Fact(DisplayName = "Teste Criação de Produto, Cliente e Pegar Taxa")]
        public void CreateProductAndClientAndProductAndGetRescue()
        {
            Product _product = new Product("EGIE3", 250, DateTime.Now, DateTime.Now.AddYears(1));
            Client _client = new Client("Kaoe", "00000000000");
            Order order = new Order(_client);


            var expected = true;

            order.AddProducts(new Product("EGIE3", 250, DateTime.Now, DateTime.Now.AddYears(1)));
            order.ReturnProductTax(_product);
            order.PlaceOrder();
            Assert.Equal(expected, _client.Valid);
        }
        [Fact(DisplayName = "Teste de Nome De Cliente Nulo - Domain Notification")]
        public void NullClientNameNotification()
        {
            Product _product = new Product("EGIE3", 250, DateTime.Now, DateTime.Now.AddYears(1));
            Client _client = new Client(null, null);
            Order order = new Order(_client);


            var expected = true;

            order.AddProducts(_product);
            order.ReturnProductTax(_product);
            order.PlaceOrder();
            Assert.Equal(expected, _client.Invalid);
        }

        [Fact(DisplayName = "Teste de Cliente Nome minimo 3 Caractere - Domain Notification")]
        public void ShortClientNameNotification()
        {
            Product _product = new Product("EGIE3", 250, DateTime.Now, DateTime.Now.AddYears(1));
            Client _client = new Client("K", "00000000000");
            Order order = new Order(_client);


            var expected = true;

            order.AddProducts(_product);
            order.ReturnProductTax(_product);
            order.PlaceOrder();
            Assert.Equal(expected, _client.Invalid);

        }
        [Fact(DisplayName = "Teste de Cliente CPF invalido - Domain Notification")]
        public void CPFInvalidNotification()
        {
            Product _product = new Product("EGIE3", 250, DateTime.Now, DateTime.Now.AddYears(1));
            Client _client = new Client("Kaoe", "00000");
            Order order = new Order(_client);


            var expected = true;

            order.AddProducts(_product);
            order.ReturnProductTax(_product);
            order.PlaceOrder();
            Assert.Equal(expected, _client.Invalid);
        }
        [Fact(DisplayName = "Teste de Retornar mais de um item ao adicionar os produtos")]
        public void AddProductsValues()
        {
            var _product = new Product("EGIE3", 250, DateTime.Now, DateTime.Now.AddYears(1));
            var _client = new Client("Kaoe", "00000");
            var order = new Order(_client);

            order.AddProducts(new Product("EGIE1", 250, DateTime.Now, DateTime.Now.AddYears(1)));
            order.AddProducts(new Product("EGIE2", 150, DateTime.Now, DateTime.Now.AddYears(5)));
            order.AddProducts(new Product("EGIE3", 10, DateTime.Now, DateTime.Now.AddYears(6)));
            order.AddProducts(new Product("EGIE4", 5, DateTime.Now, DateTime.Now.AddYears(1)));
            order.AddProducts(new Product("EGIE5", 800, DateTime.Now, DateTime.Now.AddYears(2)));

            order.ReturnProductTax(_product);
            order.PlaceOrder();
            Assert.Equal(5, order.Products.Count);
        }
    }
}
