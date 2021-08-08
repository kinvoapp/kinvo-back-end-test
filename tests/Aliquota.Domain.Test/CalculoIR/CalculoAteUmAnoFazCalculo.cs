using Aliquota.Domain.Servicos.CalculoIR.Calculos;
using System;
using Xunit;

namespace Aliquota.Domain.Test.CalculoIR
{
    public class CalculoAteUmAnoFazCalculo
    {
        [Theory]
        [InlineData("2021-04-01", "2022-03-31",55,12.38)]
        public void CalculaValorIRNaPorcentagemCorretaEmAplicacaoDeAteUmAno(DateTime dataAplicacao,DateTime dataResgate,double lucro,double valorIREsperado)
        {
            var calculo = new CalculoAteUmAno();
            var valorIR = 0.0;
            calculo.FazCalculo(ref valorIR, lucro,dataAplicacao, dataResgate);
            Assert.Equal(valorIREsperado, valorIR);
        }

        [Theory]
        [InlineData("2021-04-01", "2022-05-31", 55, 0)]
        public void NaoCalculaValorIREmAplicacaoComMaisDeUmAno(DateTime dataAplicacao, DateTime dataResgate, double lucro, double valorIREsperado)
        {
            var calculo = new CalculoAteUmAno();
            var valorIR = 0.0;
            calculo.FazCalculo(ref valorIR, lucro, dataAplicacao, dataResgate);
            Assert.Equal(valorIREsperado, valorIR);
        }

    }
}
