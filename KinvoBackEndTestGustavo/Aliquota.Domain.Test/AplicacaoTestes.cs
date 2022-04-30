using Aliquota.Domain.Dominios.AplicacaoModule;
using Aliquota.Domain.Dominios.ProdutoModule;
using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class AplicacaoTestes
    {
        Produto produtoTeste = new(0, "produtoVazio");

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
            double aplicationValue = 350;
            Aplicacao aplicacao = new(0, produtoTeste, aplicationValue, dataSeisMesesAtras, null);

            //Action
            double lucro = 75;
            double aplicacaoTaxada = aplicationValue + lucro * 0.775;
            aplicacao.Resgatar(aplicacao, lucro, DateTime.Now);

            //Assert
            Assert.Equal(aplicacaoTaxada, aplicacao.Valor);
        }

        [Fact]
        public void DataResgate_MenorQue_DoisAnos()
        {
            //Arrange
            double aplicationValue = 500;
            Aplicacao aplicacao = new(0, produtoTeste, aplicationValue, dataUmAnoESeisMesesAtras, null);

            //Action
            double lucro = 100;
            double aplicacaoTaxada = aplicationValue + lucro * 0.815;
            aplicacao.Resgatar(aplicacao, lucro, dataUmAnoESeisMesesAtras);

            //Assert
            Assert.Equal(aplicacaoTaxada, aplicacao.Valor);
        }

        [Fact]
        public void DataResgate_MaiorQue_DoisAnos()
        {
            //Arrange
            double aplicationValue = 10000;
            Aplicacao aplicacao = new(0, produtoTeste, aplicationValue, dataDoisAnosESeisMesesAtras, null);

            //Action
            double lucro = 1000;
            double aplicacaoTaxada = aplicationValue + lucro * 0.85;
            aplicacao.Resgatar(aplicacao, lucro, dataDoisAnosESeisMesesAtras);

            //Assert
            Assert.Equal(aplicacaoTaxada, aplicacao.Valor);
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
