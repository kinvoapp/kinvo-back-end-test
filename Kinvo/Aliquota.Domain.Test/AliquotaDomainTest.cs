using System;
using Xunit;
using Aliquota.Domain.Entidades;

namespace Aliquota.Domain.Test
{
    public class AliquotaDomainTest
    {
        [Fact]
        public void AplicarValorDeInvestimento()
        {
            //Arrange
            var l_ClienteProdFinanceiro = new ClienteProdutoFinanceiro();
            decimal l_ValorAplicado = 500;
            var l_Expected = true;

            //Act
            var l_result = l_ClienteProdFinanceiro.AplicarInvestimento(l_ValorAplicado);

            //Assert
            
            Assert.Equal(l_Expected, l_result);
        }

        [Fact]
        public void ResgatarValorDeInvestimento()
        {
            //Arrange
            var l_ClienteProdFinanceiro = new ClienteProdutoFinanceiro();
            DateTime l_DataResgate = new DateTime(2021, 12, 01);
            //Act
            var l_Result = l_ClienteProdFinanceiro.ResgatarInvestimento(l_DataResgate);
            var l_Expected = true;

            //Assert
            Assert.Equal(l_Expected, l_Result);
        }
    }
}
