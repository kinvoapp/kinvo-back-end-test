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
            String dataResgate = "13/04/2021";
            String dataAplicacao = "11/04/1999";
            double taxaAnual = 0.01;
            double valor = 1000;

            Lucro l = new Lucro(dataResgate, dataAplicacao, taxaAnual, valor);

            var ir = l.getIR(l);
            var valorEsperado = 33.03;

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
        [InlineData("12/05/2018", "13/04/2021", 0.01, 4000, 17.54)]
        [InlineData("27/11/2019", "13/04/2021", 0.01, 3000, 7.65)]
        [InlineData("08/05/2020", "13/04/2021", 0.01, 2500, 5.24)]
        public void testAliquotaRelativo(String dA, String dR, double taxa, double valor, double valorEsperado)
        {
            Lucro l = new Lucro(dR, dA, taxa, valor);

            var ir = l.getIR(l);

            Assert.Equal(valorEsperado, ir, 1);
        }
    }
}
