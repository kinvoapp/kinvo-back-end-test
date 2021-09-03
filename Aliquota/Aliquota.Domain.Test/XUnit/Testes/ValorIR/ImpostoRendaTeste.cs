using Aliquota.Domain.Business.Implementacao.Business.IRFactory;
using Aliquota.Domain.Business.Implementacao.Business.IRStrategy;
using Aliquota.Domain.Entities.Entidades;
using Aliquota.Domain.Test.XUnit.Testes.ValorIR.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Aliquota.Domain.Test.XUnit.Testes.ValorIR
{
    public class ImpostoRendaTeste
    {
        [Fact]
        [Trait("Category", "Menor1ano")]
        public void Teste_Menor1ano()
        {
            // Arrange
            var produto = new Produto();
            produto.DataInvestimento = new DateTime(2020, 01, 01);
            produto.DataResgate = new DateTime(2020, 12, 01);
            produto.ValorInvestido = 10;
            produto.ValorAtual = 15;

            // Act
            var strategy = DefineIrFactory.create(produto);

            // Assert
            Assert.IsType<IR1anoStrategy>(strategy);
            Assert.IsNotType<IRde1Ate2anosStrategy>(strategy);
            Assert.IsNotType<IRMaior2anosStrategy>(strategy);
        }
        [Fact]
        [Trait("Category", "Entre1e2anos")]
        public void Teste_Entre1e2anos()
        {
            // Arrange
            var produto = new Produto();
            produto.DataInvestimento = new DateTime(2020, 01, 01);
            produto.DataResgate = new DateTime(2021, 12, 01);
            produto.ValorInvestido = 10;
            produto.ValorAtual = 15;
            // Act
            var strategy = DefineIrFactory.create(produto);

            // Assert
            Assert.IsType<IRde1Ate2anosStrategy>(strategy);
            Assert.IsNotType<IR1anoStrategy>(strategy);
            Assert.IsNotType<IRMaior2anosStrategy>(strategy);
        }
        [Fact]
        [Trait("Category", "Maior2Anos")]
        public void Teste_Maior2Anos()
        {
            // Arrange
            var produto = new Produto();
            produto.DataInvestimento = new DateTime(2020, 01, 01);
            produto.DataResgate = new DateTime(2024, 12, 01);
            produto.ValorInvestido = 10;
            produto.ValorAtual = 15;

            // Act
            var strategy = DefineIrFactory.create(produto);

            // Assert
            
            Assert.IsType<IRMaior2anosStrategy>(strategy);
            Assert.IsNotType<IRde1Ate2anosStrategy>(strategy);
            Assert.IsNotType<IR1anoStrategy>(strategy);
        }

        [Theory]
        [ClassData(typeof(IRprodutoTesteData))]
        public void Teste_Data_Atingimento(Produto produto, decimal valorEsperado)
        {
            var strategy = DefineIrFactory.create(produto);
            produto.ValorImposto = strategy.CalculaImposto();
            // Assert
            Assert.Equal(produto.ValorImposto, valorEsperado);
        }
    }
}
