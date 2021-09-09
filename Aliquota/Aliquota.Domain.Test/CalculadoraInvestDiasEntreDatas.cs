using System;
using Xunit;
using Aliquota.Domain;

namespace Aliquota.Domain.Test
{
    public class CalculadoraInvestDiasEntreDatas
    {
        [Theory]
        [InlineData("2021-08-02", "2021-08-01")]
        [InlineData("2020-12-31", "2020-01-01")]
        public void NaoAceitaDataFinalMenorQueInicial(DateTime dataInicial, DateTime dataFinal)
            //Assert
            =>  Assert.Throws<ArgumentException>(
                        //Act
                        () => CalculadoraInvest.DiasEntreDatas(dataInicial, dataFinal)
                      );

        [Theory]
        [InlineData(1, "2021-02-01", "2021-02-02")]
        [InlineData(0, "2021-02-01", "2021-02-01")]
        [InlineData(59, "2021-01-01", "2021-03-01")]
        [InlineData(334, "2021-01-01", "2021-12-01")]
        [InlineData(3926, "2010-07-31", "2021-04-30")]
        public void CalculaDiferencaEntreDatas(int diasEsperados, DateTime dataInicial, DateTime dataFinal)
        {
            //ACt
            var diasObtido = CalculadoraInvest.DiasEntreDatas(dataInicial, dataFinal);

            //Assert
            Assert.Equal(diasEsperados, diasObtido);
        }

    }
}
