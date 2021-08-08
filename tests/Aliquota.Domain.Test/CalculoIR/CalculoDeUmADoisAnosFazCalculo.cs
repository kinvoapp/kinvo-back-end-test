using Aliquota.Domain.Servicos.CalculoIR.Calculos;
using System;
using Xunit;

namespace Aliquota.Domain.Test.CalculoIR
{
    public class CalculoDeUmADoisAnosFazCalculo
    {
        [Theory]
        [InlineData("2021-04-01", "2023-03-09", 55, 10.18)]
        public void CalculaValorIRNaPorcentagemCorretaEmAplicacaoDeUmADoisAnos(DateTime dataAplicacao, DateTime dataResgate, double lucro, double valorIREsperado)
        {
            var calculo = new CalculoDeUmADoisAnos();
            var valorIR = 0.0;
            calculo.FazCalculo(ref valorIR, lucro, dataAplicacao, dataResgate);
            Assert.Equal(valorIREsperado, valorIR);
        }

        [Theory]
        [InlineData("2021-04-01", "2023-05-11", 55, 0)]
        public void NaoCalculaValorIREmAplicacaoComMaisDeDoisAnos(DateTime dataAplicacao, DateTime dataResgate, double lucro, double valorIREsperado)
        {
            var calculo = new CalculoDeUmADoisAnos();
            var valorIR = 0.0;
            calculo.FazCalculo(ref valorIR, lucro, dataAplicacao, dataResgate);
            Assert.Equal(valorIREsperado, valorIR);
        }

        [Theory]
        [InlineData("2021-04-01", "2021-06-07", 55, 0)]
        public void NaoCalculaValorIREmAplicacaoComMenosDeUmAno(DateTime dataAplicacao, DateTime dataResgate, double lucro, double valorIREsperado)
        {
            var calculo = new CalculoDeUmADoisAnos();
            var valorIR = 0.0;
            calculo.FazCalculo(ref valorIR, lucro, dataAplicacao, dataResgate);
            Assert.Equal(valorIREsperado, valorIR);
        }
    }
}
