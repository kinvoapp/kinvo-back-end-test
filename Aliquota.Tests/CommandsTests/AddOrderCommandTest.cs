using System;
using System.Collections.Generic;
using Aliquota.Domain.Commands;
using Aliquota.Domain.Entities;
using Xunit;
namespace Aliquota.Domain.Test.CommandsTests
{
    //User manda JSON -> é convertido para Command e é chamado o método Valid(valida na hora)
    public class AddOrderCommandTest
    {
        [Fact]
        public void CreateSuccessCommand()
        {
            var _product = new List<Product>();
            var command = new AddOrderCommand();
            command.CustomerId = Guid.NewGuid();
            command.Products = _product;

            Assert.Equal(true, command.Valid);
        }
    }
}
