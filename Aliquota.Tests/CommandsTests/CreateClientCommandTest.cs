using System;
using Aliquota.Domain.Commands;
using Xunit;
namespace Aliquota.Domain.Test.CommandsTests
{
    public class RescueProductTaxCommandTest
    {
        [Fact]
        public void CreateSuccessCommand()
        {
            var command = new CreateClientCommand();
            command.Document = "00000000000";
            command.User = "Kaoe";

            Assert.Equal(true, command.Valid);
        }
        [Fact]
        public void CreateFailCommand()
        {
            var command = new CreateClientCommand();
            command.Document = "00000000";
            command.User = "Kae";

            Assert.Equal(false, command.Invalid);
        }
    }
}
