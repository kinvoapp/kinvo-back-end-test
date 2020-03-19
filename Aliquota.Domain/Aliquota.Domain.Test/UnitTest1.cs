using Aliquota.Domain.Entities;
using Application;
using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class AplicacaoUnitTest
    {
        [Fact]
        public void Aplicacao_Valor0_Invalida()
        {
            Aplicacao l_Aplicacao = new Aplicacao();
            l_Aplicacao.Valor = 0;
            var l_Resultado = AppAplicacao.ValidarAplicacao(l_Aplicacao);

            Assert.False(l_Resultado, "ValidarAplicacao - Aplicação não pode ter valor <= 0");
        }

        [Fact]
        public void Aplicacao_ValorMaiorQue0_Valido()
        {
            Aplicacao l_Aplicacao = new Aplicacao();
            l_Aplicacao.Valor = 10;
            var l_Resultado = AppAplicacao.ValidarAplicacao(l_Aplicacao);

            Assert.True(l_Resultado, "ValidarAplicacao - Aplicação com valor maior que 0 é válida");
        }

        [Fact]
        public void Aplicacao_DataRetiradaMenorDataAplicacao_Invalida()
        {
            Aplicacao l_Aplicacao = new Aplicacao();
            l_Aplicacao.Valor = 10;
            DateTime l_DateTimeNow = DateTime.Now;
            l_Aplicacao.DataAplicacao = l_DateTimeNow.AddMonths(2);
            l_Aplicacao.DataRetirada = l_DateTimeNow;
            var l_Resultado = AppAplicacao.ValidarAplicacao(l_Aplicacao);

            Assert.False(l_Resultado, "ValidarAplicacao - Aplicação não pode ter Data Aplicação > Data Retirada");
        }

        [Fact]
        public void Aplicacao_DataRetiradaMaiorDataAplicacao_Valida()
        {
            Aplicacao l_Aplicacao = new Aplicacao();
            l_Aplicacao.Valor = 10;
            DateTime l_DateTimeNow = DateTime.Now;
            l_Aplicacao.DataAplicacao = l_DateTimeNow;
            l_Aplicacao.DataRetirada = l_DateTimeNow.AddMonths(2);
            var l_Resultado = AppAplicacao.ValidarAplicacao(l_Aplicacao);

            Assert.True(l_Resultado, "ValidarAplicacao - Aplicação com Data Retirada > Data Aplicação é válida");
        }

        [Fact]
        public void Aplicacao_IRDevidoDeveSer22_5()
        {
            decimal l_Resultado = AppAplicacao.ObterPercentualIR(12);

            Assert.Equal(l_Resultado, (decimal)1.225, 3);
        }

        [Fact]
        public void Aplicacao_IRDevidoDeveSer18_5()
        {
            decimal l_Resultado = AppAplicacao.ObterPercentualIR(16);

            Assert.Equal(l_Resultado, (decimal)1.185, 3);
        }

        [Fact]
        public void Aplicacao_IRDevidoDeveSer15()
        {
            decimal l_Resultado = AppAplicacao.ObterPercentualIR(32);

            Assert.Equal(l_Resultado, (decimal)1.15, 2);
        }
    }
}

