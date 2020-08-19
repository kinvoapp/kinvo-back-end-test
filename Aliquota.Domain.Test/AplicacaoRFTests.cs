using Aliquota.Domain.Entities;
using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class AplicacaoRFTests
    {
        #region Atributos processados
        [Theory]
        [InlineData("2015-03-25", "2015-06-25", 22.5)]// 3 meses de aplicação
        [InlineData("2015-03-25", "2016-03-25", 22.5)]// 1 ano exato
        [InlineData("2015-03-25", "2016-03-26", 18.5)]// 1 ano e 1 dia
        [InlineData("2015-03-25", "2016-09-25", 18.5)]// 1 ano e meio
        [InlineData("2015-03-25", "2017-03-25", 18.5)]// 2 anos exatos
        [InlineData("2015-03-25", "2017-03-26", 15)]// 2 anos e 1 dia
        [InlineData("2015-03-25", "2020-03-25", 15)]// 5 anos
        public void AliquotaIR(string pDataAplicacao, string pDataResgate, decimal pAliquota)
        {
            var lAplicacao = new AplicacaoRF()
            {
                DataAplicacao = Convert.ToDateTime(pDataAplicacao),
                DataResgate = Convert.ToDateTime(pDataResgate)
            };

            Assert.Equal(pAliquota, lAplicacao.AliquotaIR);
        }

        [Theory]
        [InlineData("2015-03-25", "2016-03-25", 1000, 5, 50)]// 1 ano exato
        [InlineData("2015-03-25", "2017-03-25", 1000, 5, 102.5)]// 2 anos exatos
        [InlineData("2015-03-25", "2017-04-29", 1000, 5, 107.66)]// 2 anos e 25 dias rentáveis (5 semanas)
        [InlineData("2020-08-14", "2020-08-16", 1000, 5, 0)]// domingo, dois dias após a aplicação
        [InlineData("2020-08-14", "2020-08-17", 1000, 5, 0.19)]// segunda feira, 3º dia após a aplicação (primeiro dia de rendimento)
        [InlineData("2020-08-14", "2020-08-21", 1000, 5, 0.94)]// uma semana de rendimento (5 dias)
        public void Rendimento(string pDataAplicacao, string pDataResgate, decimal pValorAplicacao, decimal pTaxaJurosAnual, decimal pRendimento)
        {
            var lAplicacao = new AplicacaoRF()
            {
                DataAplicacao = Convert.ToDateTime(pDataAplicacao),
                DataResgate = Convert.ToDateTime(pDataResgate),
                ValorAplicado = pValorAplicacao,
                TaxaJurosAnual = pTaxaJurosAnual
            };
            Assert.Equal(Decimal.Round(pRendimento, 2), Decimal.Round(lAplicacao.RendimentoTotal, 2));
        }


        [Theory]
        [InlineData("2015-03-25", "2016-03-25", 1000, 5, 11.25)]// IR de 1 ano
        [InlineData("2015-03-25", "2017-03-25", 1000, 5, 18.96)]// IR de 2 anos
        [InlineData("2015-03-25", "2018-03-25", 1000, 5, 23.64)]// IR de 3 anos
        public void IRRecolhido(string pDataAplicacao, string pDataResgate, decimal pValorAplicacao, decimal pTaxaJurosAnual, decimal pIRRecolhido)
        {
            var lAplicacao = new AplicacaoRF()
            {
                DataAplicacao = Convert.ToDateTime(pDataAplicacao),
                DataResgate = Convert.ToDateTime(pDataResgate),
                ValorAplicado = pValorAplicacao,
                TaxaJurosAnual = pTaxaJurosAnual
            };
            Assert.Equal(Decimal.Round(pIRRecolhido, 2), Decimal.Round(lAplicacao.IRRecolhido, 2));

        }

        #endregion

        #region Validações
        [Theory]
        [InlineData("2015-03-25", "2015-03-25")] //Aplicação e Resgate no mesmo dia
        public void PeriodoValido(string pDataAplicacao, string pDataResgate)
        {
            AplicacaoRF lAplicacao;
            //Ao atribuir data inicial
            lAplicacao = new AplicacaoRF()
            {
                DataAplicacao = Convert.ToDateTime(pDataAplicacao),
                DataResgate = Convert.ToDateTime(pDataResgate)
            };
        }

        [Theory]
        [InlineData("2015-03-25", "2015-03-24")]//Resgate anterior à aplicação
        public void PeriodoInvalido(string pDataAplicacao, string pDataResgate)
        {
            AplicacaoRF lAplicacao;

            //Ao atribuir data inicial
            lAplicacao = new AplicacaoRF()
            {
                DataResgate = Convert.ToDateTime(pDataResgate),
            };
            Assert.Throws<ArgumentException>(() => lAplicacao.DataAplicacao = Convert.ToDateTime(pDataAplicacao));

            //Ao atribuir data final
            lAplicacao = new AplicacaoRF()
            {
                DataAplicacao = Convert.ToDateTime(pDataAplicacao),
            };
            Assert.Throws<ArgumentException>(() => lAplicacao.DataResgate = Convert.ToDateTime(pDataResgate));
        }

        [Theory]
        [InlineData(0.01)]
        [InlineData(1)]
        public void ValorAplicadoValido(decimal pValorAplicado)
        {
            AplicacaoRF lAplicacaoRF = new AplicacaoRF()
            {
                ValorAplicado = pValorAplicado
            };
        }

        [Theory]
        [InlineData(0.001)]
        [InlineData(-0.01)]
        [InlineData(0)]
        public void ValorAplicadoInvalido(decimal pValorAplicado)
        {
            AplicacaoRF lAplicacaoRF = new AplicacaoRF() { };
            Assert.Throws<ArgumentException>(() => lAplicacaoRF.ValorAplicado = pValorAplicado);
        }

        #endregion

    }
}
