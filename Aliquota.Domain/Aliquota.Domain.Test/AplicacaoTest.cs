using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class AplicacaoTest
    {
        [Fact]
        public void CriarAplicacao_ValorZero_ReturnsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Aplicacao(0));
        }

        [Fact]
        public void CriarAplicacao_ValorNegativo_ReturnsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Aplicacao(-0.01));
        }

        [Fact]
        public void CriarAplicacao_ValorPositivo_ReturnsAplicacao()
        {
            Assert.IsType<Aplicacao>(new Aplicacao(0.01));
        }

        [Fact]
        public void ResgatarAplicacao_DataResgateMaiorDataAplicacao_ReturnsDouble()
        {
            Aplicacao aplicacao = new Aplicacao(1);
            aplicacao.DataCriacao = aplicacao.DataCriacao.AddDays(-1);
            Assert.IsType<double>(aplicacao.ResgatarAplicacao());
        }

        [Fact]
        public void ResgatarAplicacao_DataResgateMenorDataAplicacao_ReturnsArgumentException()
        {
            Aplicacao aplicacao = new Aplicacao(1);
            aplicacao.DataCriacao = aplicacao.DataCriacao.AddDays(1);
            Assert.Throws<ArgumentException>(() => aplicacao.ResgatarAplicacao());
        }

        [Fact]
        public void CalcularTaxaIR_DataAplicacaoMenorQueUmAno_Returns22_5()
        {
            Aplicacao aplicacao = new Aplicacao(1);
            aplicacao.ValorLucro = 100;
            aplicacao.DataCriacao = DateTime.Now.AddMonths(-1);
            Assert.Equal(22.5, aplicacao.TaxaIR());
        }

        [Fact]
        public void CalcularTaxaIR_DataAplicacaoAcimaDeUmAnoEAbaixoOuIgualADoisAnos_Returns18_5()
        {
            Aplicacao aplicacao = new Aplicacao(1);
            aplicacao.ValorLucro = 100;
            aplicacao.DataCriacao = DateTime.Now.AddYears(-1);
            Assert.Equal(18.5, aplicacao.TaxaIR());
        }

        [Fact]
        public void CalcularTaxaIR_DataAplicacaoAcimaDeDoisAnos_Returns15()
        {
            Aplicacao aplicacao = new Aplicacao(1);
            aplicacao.ValorLucro = 100;
            aplicacao.DataCriacao = DateTime.Now.AddYears(-2);
            Assert.Equal(15, aplicacao.TaxaIR());
        }

    }
}
