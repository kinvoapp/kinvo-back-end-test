using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class ProdutoFinanceiroTeste
    {
        //nomeDoMetodo_cenario_resultadoEsperado
        [Fact]
        public void aplicarMontante_valorAplicadoPositivo_valorInvestidoAtualizadoComValorAplicado()
        {
            //Arrange
            ProdutoFinanceiro produtoFinanceiro = new ProdutoFinanceiro();
            var resultadoEsperado = 10000;

            //Act
            produtoFinanceiro.aplicarMontante(10000);

            //Assert
            Assert.Equal(produtoFinanceiro.ValorInvestidoAtual, resultadoEsperado);
        }

        [Fact]
        public void aplicarMontante_valorAplicadoNegativo_lancaExecao()
        {
            ProdutoFinanceiro produtoFinanceiro = new ProdutoFinanceiro();
            Assert.Throws<ArgumentOutOfRangeException>(() => produtoFinanceiro.aplicarMontante(-100));
        }

        [Fact]
        public void calcularLucro_tempoDecorridoValido_lucroTotalCalculado()
        {
            ProdutoFinanceiro produtoFinanceiro = new ProdutoFinanceiro();
            produtoFinanceiro.ValorInvestidoAtual = 1000;

            var resultadoEsperado = 120; //1000 reais aplicados durante 12 meses = 1000 * 12 * 0.01 = 120

            Assert.Equal(resultadoEsperado, produtoFinanceiro.calcularLucro(12));
        }

        [Fact]
        public void resgatarMontante_valorResgatadoValido_valorInvestidoAtualSubtraiValorResgatado()
        {
            ProdutoFinanceiro produtoFinanceiro = new ProdutoFinanceiro();
            produtoFinanceiro.ValorInvestidoAtual = 1000;

            var resultadoEsperado = 600; //400 reais resgatados de 1000 reais investidos.
            produtoFinanceiro.resgatarMontante(400);

            Assert.Equal(resultadoEsperado, produtoFinanceiro.ValorInvestidoAtual);
        }

        [Fact]
        public void resgatarMontante_valorResgatadoIgualAZero_lancaExcecao()
        {
            ProdutoFinanceiro produtoFinanceiro = new ProdutoFinanceiro();
            produtoFinanceiro.ValorInvestidoAtual = 1000;

            Assert.Throws<ArgumentOutOfRangeException>(() => produtoFinanceiro.resgatarMontante(0));
        }

        [Fact]
        public void resgatarMontante_valorResgatadoMaiorQueValorAtualInvestido_lancaExcecao()
        {
            ProdutoFinanceiro produtoFinanceiro = new ProdutoFinanceiro();
            produtoFinanceiro.ValorInvestidoAtual = 1000;

            Assert.Throws<ArgumentOutOfRangeException>(() => produtoFinanceiro.resgatarMontante(2000));
        }

        [Fact]
        public void calcularTempo_dataFinalMaiorDataInicial_calculaTempo()
        {
            ProdutoFinanceiro produtoFinanceiro = new ProdutoFinanceiro();
            DateTime dataInicial = new DateTime(2019, 1, 1);
            DateTime dataFinal = new DateTime(2020, 1, 1);

            var resultadoEsperado = 12; //12 meses decorridos entre a data inicial e a final

            var resultadoFinal = produtoFinanceiro.calcularTempo(dataInicial, dataFinal);

            Assert.Equal(resultadoEsperado, resultadoFinal);
        }

        [Fact]
        public void calcularTempo_dataInicialMaiorDataFinal_lancaExcecao()
        {
            ProdutoFinanceiro produtoFinanceiro = new ProdutoFinanceiro();
            DateTime dataInicial = new DateTime(2020, 1, 1);
            DateTime dataFinal = new DateTime(2019, 1, 1);

            Assert.Throws<ArgumentOutOfRangeException>(() => produtoFinanceiro.calcularTempo(dataInicial, dataFinal));
        }

        [Fact]
        public void calcularImpostoDeRenda_tempoDecorridoMenor1Ano_calculaIR()
        {
            ProdutoFinanceiro produtoFinanceiro = new ProdutoFinanceiro();
            produtoFinanceiro.DataAplicacao = new DateTime(2010, 1, 1);
            produtoFinanceiro.DataResgate2 = new DateTime(2010, 7, 1);
            produtoFinanceiro.LucroTotal = 60;

            var resultadoEsperado = 13.5; // 22.5% de 60 = 13.5
            produtoFinanceiro.calcularImpostoDeRenda();
            var resultadoFinal = produtoFinanceiro.ValorRecolhidoIR;

            Assert.Equal(resultadoEsperado, resultadoFinal);
        }

        [Fact]
        public void calcularImpostoDeRenda_tempoDecorridoEntreUmEDoisAnos_calculaIR()
        {
            ProdutoFinanceiro produtoFinanceiro = new ProdutoFinanceiro();
            produtoFinanceiro.DataAplicacao = new DateTime(2010, 1, 1);
            produtoFinanceiro.DataResgate2 = new DateTime(2011, 6, 1);
            produtoFinanceiro.LucroTotal = 150;

            var resultadoEsperado = 27.75; // 18.5% de 150 = 27.5
            produtoFinanceiro.calcularImpostoDeRenda();
            var resultadoFinal = produtoFinanceiro.ValorRecolhidoIR;

            Assert.Equal(resultadoEsperado, resultadoFinal);
        }

        [Fact]
        public void calcularImpostoDeRenda_tempoDecorridoMaiorDoisAnos_calculaIR()
        {
            ProdutoFinanceiro produtoFinanceiro = new ProdutoFinanceiro();
            produtoFinanceiro.DataAplicacao = new DateTime(2010, 1, 1);
            produtoFinanceiro.DataResgate2 = new DateTime(2012, 7, 1);
            produtoFinanceiro.LucroTotal = 300;

            var resultadoEsperado = 45; // 15% de 300 = 45
            produtoFinanceiro.calcularImpostoDeRenda();
            var resultadoFinal = produtoFinanceiro.ValorRecolhidoIR;

            Assert.Equal(resultadoEsperado, resultadoFinal);
        }

        [Fact]
        public void calcularValorResgatado_ListaPreenchida_calculaValorResgatado()
        {
            ProdutoFinanceiro produtoFinanceiro = new ProdutoFinanceiro();
            Cliente cliente = new Cliente();
            cliente.valorResgatado = new System.Collections.Generic.List<float>();

            cliente.valorResgatado.Add(1000);
            cliente.valorResgatado.Add(2000);
            cliente.valorResgatado.Add(3000);

            var resultadoEsperado = 6000;
            var resultadoFinal = produtoFinanceiro.calcularValorResgatado(cliente.valorResgatado);

            Assert.Equal(resultadoEsperado, resultadoFinal);
        }

        [Fact]
        public void calcularValorResgatado_listaNaoInicializada_lancaExcecao()
        {
            ProdutoFinanceiro produtoFinanceiro = new ProdutoFinanceiro();
            Cliente cliente = new Cliente();

            Assert.Throws<ArgumentNullException>(() => produtoFinanceiro.calcularValorResgatado(cliente.valorResgatado));
        }
    }
}
