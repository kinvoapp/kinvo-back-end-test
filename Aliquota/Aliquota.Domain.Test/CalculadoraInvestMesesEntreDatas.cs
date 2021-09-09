using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class CalculadoraInvestMesesEntreDatas
    {
        [Fact]
        public void NumeroDeMesesEntreDuasDatas()
        {
            var dataInicial = new DateTime(2020, 12, 31);
            var dataFinal = new DateTime(2021, 12, 31);
            
            var valorEsperado = 12;

            var numeroMeses = CalculadoraInvest.MesesEntreDatas(dataInicial, dataFinal);

            Assert.Equal(valorEsperado, numeroMeses);
        }


    }
}
