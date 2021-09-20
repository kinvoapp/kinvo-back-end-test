using System;
using Aliquota.Domain.Commands;
using Xunit;

namespace Aliquota.Domain.Test.CommandsTests
{
    public class RescueProductTaxCommandTest
    {
        [Fact(DisplayName = "Teste Criação do Imposto Command Create - Success(Válido)")]
        public void CreateProductCommandValid()
        {
            var command = new RescueProductApplicationCommand("EGIE3", 250, DateTime.Now, DateTime.Now.AddYears(1));
            var result = true;
            command.Validate();
            Assert.Equal(result, command.Valid);
        }
        [Fact(DisplayName = "Teste Criação do Imposto Command Create - Error (Inválido)")]
        public void CreateProductCommandInvalid()
        {
            var command = new RescueProductApplicationCommand("", 0, DateTime.Now, DateTime.Now.AddYears(1));
            var result = false;
            command.Validate();
            Assert.Equal(result, command.Valid);
        }
    }
}
