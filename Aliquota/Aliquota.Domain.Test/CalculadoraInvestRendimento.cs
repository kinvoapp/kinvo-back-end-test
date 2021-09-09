using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class CalculadoraInvestRendimento
    {
        [Theory]
        [InlineData(0, 2, 10)]
        public void CapitalInicialNaoPodeSerMenorOuIgualZero(double capitalInicial, float taxa, int tempo)
            => Assert.Throws<ArgumentOutOfRangeException>(
                          () => CalculadoraInvest.RendimentoDoInvestimento(capitalInicial, taxa, tempo)
                      );

        [Theory]
        [InlineData(1004.94, 1000, 3, 60)]
        [InlineData(2234.43, 2000, 7, 578)]
        [InlineData(1525271.43, 100000, 12.62, 7882)]
        [InlineData(10.03, 10, 12.62, 9)]
        [InlineData(10, 10, 2, 9)]
        [InlineData(2, 2, 2, 9)]
        [InlineData(500.27, 500, 10, 2)]
        public void CalcularRendimentoDoInvestimento(double rendimentoEsperado, double capital, double taxaAnual, int tempoDoInvestimentoEmDias)
        {
            var rendimentoObtido = CalculadoraInvest.RendimentoDoInvestimento(capital, taxaAnual, tempoDoInvestimentoEmDias);
            Assert.Equal(rendimentoEsperado, rendimentoObtido);
        }

    }
}
