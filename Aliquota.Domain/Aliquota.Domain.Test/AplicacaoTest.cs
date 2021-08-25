using Aliquota.Domain.Models;
using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class AplicacaoTest
    {
        [Fact]
        public void CalculoIrTest_4Meses_Mensal()
        {
            Aplicacao aplicacao = new Aplicacao();
            aplicacao.AplicacaoId = 1;
            aplicacao.ClienteId = 1;
            aplicacao.Data = new DateTime(2021, 4, 9);
            aplicacao.Periodicidade = Aplicacao.Periodicidades.Mensal;
            aplicacao.TaxaLucro = 0.5;
            aplicacao.Valor = 1000.00;

            var valorEsperado = 4.53;
            var ir = aplicacao.calculaIR(new DateTime(2021, 8, 24));

            Assert.Equal(valorEsperado, ir);
        }

        [Fact]
        public void CalculoIrTest_2Anos_Anual()
        {
            Aplicacao aplicacao = new Aplicacao();
            aplicacao.AplicacaoId = 1;
            aplicacao.ClienteId = 1;
            aplicacao.Data = new DateTime(2019, 4, 9);
            aplicacao.Periodicidade = Aplicacao.Periodicidades.Anual;
            aplicacao.TaxaLucro = 0.5;
            aplicacao.Valor = 1000.00;

            var valorEsperado = 1.50;
            var ir = aplicacao.calculaIR(new DateTime(2021, 4, 9));

            Assert.Equal(valorEsperado, ir);
        }
    }
}
