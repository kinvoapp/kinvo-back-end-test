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
            var _product = new Product("EGIE1", 250, DateTime.Now, DateTime.Now.AddYears(1));
            var command = new AddOrderCommand();

            command.ClientDocument = "00000000011";
            command.ProductTitle = "EGIE1";

            Assert.Equal(true, command.Valid);
            //Assert.Equal(true, command.Valid);
        }
        [Fact]
        public void CreateFailCommand()
        {
            var _product = new Product("EGIE1", 250, DateTime.Now, DateTime.Now.AddYears(1));
            var command = new AddOrderCommand();

            command.ClientDocument = "00011";
            command.ProductTitle = "EGI";

            Assert.Equal(false, command.Invalid);
            //Assert.Equal(true, command.Valid);
        }
    }
}
