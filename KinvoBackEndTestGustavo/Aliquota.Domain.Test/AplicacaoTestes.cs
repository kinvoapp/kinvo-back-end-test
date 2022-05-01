using Aliquota.Domain.AplicacaoModule;
using Aliquota.Domain.ProdutoModule;
using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class AplicacaoTestes
    {
        readonly Produto produtoTeste;

        private string resultadoAplicacao_MenorOuIgualZero;
        private string resultadoAplicacao_ProdutoVazio;
        private string resultadoDataResgate_MenorQueDataAplicacao;
        private DateTime dataAgora;
        private DateTime dataSeisMesesAtras;
        private DateTime dataUmAnoESeisMesesAtras;
        private DateTime dataDoisAnosESeisMesesAtras;
        public AplicacaoTestes()
        {
            DefineMensagensDasValidacoes();
            DefineDatas();
            produtoTeste = new(0, "produto");
        }

        [Fact]
        public void ImpostoRenda_PropriedadesInvalidas()
        {
            //Arrange
            Aplicacao aplicacao = new(0, null, 0, dataAgora, dataAgora.AddDays(-1));

            //Action
            string resultado = aplicacao.Validar();

            //Assert
            Assert.Equal(resultadoAplicacao_MenorOuIgualZero
                + resultadoAplicacao_ProdutoVazio
                + resultadoDataResgate_MenorQueDataAplicacao,
                resultado);
        }

        [Fact]
        public void ImpostoRenda_PropriedadesValidas()
        {
            //Arrange
            Aplicacao aplicacao = new(0, produtoTeste, 100, dataDoisAnosESeisMesesAtras, dataAgora);

            //Action
            string resultado = aplicacao.Validar();

            //Assert
            Assert.Equal("VALIDO", resultado);
        }

        [Fact]
        public void DataResgate_MenorQue_UmAno()
        {
            //Arrange
            double valorAplicacao = 350;
            Aplicacao aplicacao = new(0, produtoTeste, valorAplicacao, dataSeisMesesAtras, null);

            //Action
            double lucro = 75;
            double aplicacaoTaxada = lucro * 0.775;
            double lucroFinal = aplicacao.CalcularLucro(aplicacao, lucro, DateTime.Now);

            //Assert
            Assert.Equal(aplicacaoTaxada, lucroFinal);
        }

        [Fact]
        public void DataResgate_MenorQue_DoisAnos()
        {
            //Arrange
            double valorAplicacao = 500;
            Aplicacao aplicacao = new(0, produtoTeste, valorAplicacao, dataUmAnoESeisMesesAtras, null);

            //Action
            double lucro = 100;
            double aplicacaoTaxada = lucro * 0.815;
            double lucroFinal = aplicacao.CalcularLucro(aplicacao, lucro, DateTime.Now);

            //Assert
            Assert.Equal(aplicacaoTaxada, lucroFinal);
        }

        [Fact]
        public void DataResgate_MaiorQue_DoisAnos()
        {
            //Arrange
            double valorAplicacao = 10000;
            Aplicacao aplicacao = new(0, produtoTeste, valorAplicacao, dataDoisAnosESeisMesesAtras, null);

            //Action
            double lucro = 1000;
            double aplicacaoTaxada = lucro * 0.85;
            double lucroFinal = aplicacao.CalcularLucro(aplicacao, lucro, DateTime.Now);

            //Assert
            Assert.Equal(aplicacaoTaxada, lucroFinal);
        }

        #region Métodos Privados
        private void DefineDatas()
        {
            dataAgora = DateTime.Now;
            dataSeisMesesAtras = DateTime.Now.AddMonths(-6);
            dataUmAnoESeisMesesAtras = DateTime.Now.AddYears(-1).AddMonths(-6);
            dataDoisAnosESeisMesesAtras = DateTime.Now.AddYears(-2).AddMonths(-6);
        }

        private void DefineMensagensDasValidacoes()
        {
            resultadoAplicacao_MenorOuIgualZero = "A aplicação não pode ser igual ou menor que zero;\n";
            resultadoAplicacao_ProdutoVazio = "O produto não pode ser nulo;\n";
            resultadoDataResgate_MenorQueDataAplicacao = "A data de resgate não pode ser menor que a data de aplicação;\n";
        }
        #endregion
    }
}
