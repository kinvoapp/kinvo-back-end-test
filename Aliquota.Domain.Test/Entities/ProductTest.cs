using System;
using Aliquota.Domain.Entities;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class ProductTest
    {
        //private readonly Product _product = new Product("EGIE3", 300, DateTime.Now, DateTime.Now.AddYears(1));

        [Fact(DisplayName = "Teste Criação de Produto")]

        public void CreateProduct()
        {
            Product _product = new Product("EGIE3", 300, DateTime.Now, DateTime.Now.AddYears(1));
            Client _client = new Client("Kaoe");
            var expected = true;
            _client.AddProduct(_product);
            var result = _product.ImAlive();
            Assert.Equal(expected, result);
        }
    }
}
