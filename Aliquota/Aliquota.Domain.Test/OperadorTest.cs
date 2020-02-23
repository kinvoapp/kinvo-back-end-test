using Aliquota.Domain.Excecao;
using System;
using System.Linq;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class OperadorTest
    {

        #region Teste Metodo Aplicar
        [Fact]
        public void OperadorIR_Aplicar_DadosNulo_RetornaExcecao()
        {
            var cliente = (Cliente)null;
            var produto = new Produto("Tesouro Indireto", 0.07);

            var aplicacao = new OperadorIR(cliente, produto);

            var msg = Assert.Throws<ExcecaoNegocio>(() => aplicacao.Aplicar(123)).Message;
            var msgEsperada = "As entidades Cliente e Produto precisam existir para acontecer uma aplicação";
            Assert.Equal(msgEsperada, msg);
        }

        [Fact]
        public void OperadorIR_Aplicar_ValorAplicadoZero_RetornaExcecao()
        {
            var cliente = new Cliente("Johnny", "11122233345");
            var produto = new Produto("Tesouro Indireto", 0.07);

            var aplicacao = new OperadorIR(cliente, produto);

            var msg = Assert.Throws<ExcecaoNegocio>(() => aplicacao.Aplicar(0)).Message;
            var msgEsperada = "O valor da aplicação não pode ser menor ou igual a zero";

            Assert.Equal(msgEsperada, msg);
        }

        [Fact]
        public void OperadorIR_Aplicar_DadosCorretos_ValoresSetadosCorretos()
        {
            var cliente = new Cliente("Johnny", "11122233345");
            var produto = new Produto("Tesouro Indireto", 0.07);

            var aplicacao = new OperadorIR(cliente, produto);

            var valorAplicado = 2000;

            aplicacao.Aplicar(valorAplicado);

            Assert.Equal(cliente.produtos.FirstOrDefault().descricao, produto.descricao);
            Assert.Equal(aplicacao.valorAplicado, valorAplicado);
            Assert.Equal(cliente.patrimonio, valorAplicado);
            Assert.True(aplicacao.dataAplicacao != DateTime.MinValue);
        }
        #endregion

        #region Teste Metodo Regastar
        [Fact]
        public void OperadorIR_Resgatar_ValorAplicadoZero_RetornaExcecao()
        {
            var cliente = new Cliente("Johnny", "11122233345");
            var produto = new Produto("Tesouro Indireto", 0.07);

            var aplicacao = new OperadorIR(cliente, produto);

            var msg = Assert.Throws<ExcecaoNegocio>(() => aplicacao.Resgatar(DateTime.Now.AddDays(2))).Message;

            var msgEsperada = "Não existe valor aplicado para resgate";
            Assert.Equal(msgEsperada, msg);
        }

        [Fact]
        public void OperadorIR_Resgatar_DataRegasteMenorQueDataAplicacao_RetornaExcecao()
        {
            var cliente = new Cliente("Johnny", "11122233345");
            var produto = new Produto("Tesouro Indireto", 0.07);

            var aplicacao = new OperadorIR(cliente, produto);
            aplicacao.Aplicar(2000);

            var msg = Assert.Throws<ExcecaoNegocio>(() => aplicacao.Resgatar(DateTime.Now.AddDays(-1))).Message;

            var msgEsperada = "A data de resgate não pode ser menor ou igual a data da aplicação";
            Assert.Equal(msgEsperada, msg);
        }

        [Theory]
        [InlineData(2000, 6, 225.329, 776.132)]
        [InlineData(2000, 15, 650.842, 2867.221)]
        [InlineData(2000, 25, 1328.23, 7526.635)]
        public void OperadorIR_Resgatar_ResgateComSucesso_ValoresRetornadosCorretamente(double valorAplicado, int tempoAplicacao, double irEsperado, double lucroLiquidoEsperado)
        {
            var cliente = new Cliente("Johnny", "11122233345");
            var produto = new Produto("Tesouro Indireto", 0.07);

            var aplicacao = new OperadorIR(cliente, produto);

            aplicacao.Aplicar(valorAplicado);

            //Como a aplicação configura a data de aplicação para o momento da chamada do metodo e esse teste pode ser executado a qualquer momento
            //Irei mockar a data da aplicação para o propósito de teste
            aplicacao.dataAplicacao = new DateTime(2020, 1, 1);

            Assert.Equal(aplicacao.valorAplicado, valorAplicado);
            Assert.Equal(cliente.patrimonio, valorAplicado);

            var dataResgate = aplicacao.dataAplicacao.AddMonths(tempoAplicacao).Date;
            dataResgate.AddMonths(tempoAplicacao);

            aplicacao.Resgatar(dataResgate);

            Assert.Equal(aplicacao.impostoRenda, irEsperado);
            var patrimonioInicial = Math.Round(cliente.patrimonio - lucroLiquidoEsperado);

            Assert.Equal(patrimonioInicial, valorAplicado);
        } 
        #endregion
    }
}
