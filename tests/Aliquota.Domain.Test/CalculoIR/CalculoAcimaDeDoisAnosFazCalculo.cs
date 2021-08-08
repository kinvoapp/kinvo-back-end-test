using Aliquota.Domain.Servicos.CalculoIR.Calculos;
using System;
using Xunit;

namespace Aliquota.Domain.Test.CalculoIR
{
    public class CalculoAcimaDeDoisAnosFazCalculo
    {
        [Theory]
        [InlineData("2021-04-01", "2023-05-12", 55, 8.25)]
        public void CalculaValorIRNaPorcentagemCorretaEmAplicacaoAcimaDeDoisAnos(DateTime dataAplicacao, DateTime dataResgate, double lucro, double valorIREsperado)
        {
            var calculo = new CalculoAcimaDeDoisAnos();
            var valorIR = 0.0;
            calculo.FazCalculo(ref valorIR, lucro, dataAplicacao, dataResgate);
            Assert.Equal(valorIREsperado, valorIR);
        }

        [Theory]
        [InlineData("2021-04-01", "2022-03-31", 55, 0)]
        public void NaoCalculaValorIREmAplicacaoComMenosDeDoisAnos(DateTime dataAplicacao, DateTime dataResgate, double lucro, double valorIREsperado)
        {
            var calculo = new CalculoAcimaDeDoisAnos();
            var valorIR = 0.0;
            calculo.FazCalculo(ref valorIR, lucro, dataAplicacao, dataResgate);
            Assert.Equal(valorIREsperado, valorIR);
        }
    }
}
