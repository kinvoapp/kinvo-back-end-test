using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class AliquotaUnitTest
    {
        [Fact]
        public void testAliquota()
        {
            String dataResgate = "11/04/2020";
            String dataAplicacao = "11/04/1999";
            double taxaAnual = 0.088;
            double valor = 1000;

            Lucro l = new Lucro(dataResgate, dataAplicacao, taxaAnual, valor);

            var ir = l.getIR(l);
            var valorEsperado = 277.4;

            Assert.Equal(valorEsperado, ir, 1);
        }

        private Random gen = new Random();
        public String RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            start.AddDays(gen.Next(range));
            return start.ToString().Substring(0, 10);
        }
        [Theory]
        [InlineData("01/01/2020", "15/06/2020", 0.088, 1000, 9.00)]
        [InlineData("01/01/2020", "15/06/2021", 0.088, 1000, 23.70)]
        [InlineData("06/01/2001", "11/04/2020", 0.065, 2000, 375.80)]
        public void testAliquotaRelativo(String dA, String dR, double taxa, double valor, double valorEsperado)
        {
            Lucro l = new Lucro(dR, dA, taxa, valor);

            var ir = l.getIR(l);

            Assert.Equal(valorEsperado, ir, 1);
        }
    }
}
