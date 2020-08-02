using System;
using Aliquota.Domain.Model;
using Xunit;

namespace Aliquota.Test
{
    public class TesteUnidadeInvestimento
    {

        [Fact]
        public void TesteCriacaoInvestimentoValorInvalido()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Investimento(Convert.ToDecimal(-10.0M));
            });
        }
        [Fact]
        public void TesteCriacaoInvestimentoComZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Investimento(Convert.ToDecimal(0.0M));
            });
        }
    }
}
