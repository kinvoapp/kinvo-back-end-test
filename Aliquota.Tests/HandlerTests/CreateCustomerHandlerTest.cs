using System;
using Aliquota.Domain.Commands;
using Aliquota.Domain.Handlers;
using Aliquota.Domain.Test.Repositories;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class CreateCustomerHandlerTest
    {
        [Fact]
        public void SuccesCreateCustomer()
        {
            var command = new CreateClientCommand();
            command.Document = "00000000000";
            command.User = "KaoeF";

            var handler = new CreateOrderCommandHandler(new FakeProductsRepository());
            var result = handler.Handle(command);

            Assert.NotEqual(null, result);
            Assert.Equal(true, handler.Valid);
        }
    }
}
