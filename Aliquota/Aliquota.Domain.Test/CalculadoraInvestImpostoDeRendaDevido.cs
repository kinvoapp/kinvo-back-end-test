using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class CalculadoraInvestImpostoDeRendaDevido
    {
        [Theory]
        [InlineData(25.69, 171.24, 577)]
        [InlineData(11.01, 59.5, 18)]
        [InlineData(0.06, 0.27, 0)]
        public void CalculoDoImpostoSobreLucro(double impostoEsperado, double lucro, int numeroMesesInvestido)
        {
            var impostoCalculado = CalculadoraInvest.ImpostoDeRendaSobreLucro(lucro, numeroMesesInvestido);
            Assert.Equal(impostoEsperado, impostoCalculado);
        }


    }
}
