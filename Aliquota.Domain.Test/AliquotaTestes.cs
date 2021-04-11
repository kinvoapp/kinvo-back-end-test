using System;
using Xunit;

using Aliquota.Domain.Models;
using Aliquota.Domain.Repositorio;

namespace Aliquota.Domain.Test
{
    public class AliquotaTestes
    {
        [Fact]
        public void CalculoDeIR_AplicacaoComMenosDeUmAno_Retorna225DoLucro()
        {
            double valorEsperado = 21.02;
            LucroRepo lucroRepo = new LucroRepo();

            Aplicacoes aplicacao = new Aplicacoes()
            { 
                Data = DateTime.Parse("11/04/2020"),
                Valor = 1000,
                Rentabilidade_Mes = 1.5
            };

            double lucroTotal = lucroRepo.CalcularLucroTotal(aplicacao, 6);

            double totalIR = lucroRepo.CalcularValorIR(6, lucroTotal);

            Assert.Equal(valorEsperado.ToString("C"), totalIR.ToString("C"));
        }

        [Fact]
        public void CalculoDeIR_AplicacaoComMaisDeUmAno_Retorna185DoLucro()
        {
            double valorEsperado = 64.168176;
            LucroRepo lucroRepo = new LucroRepo();

            Aplicacoes aplicacao = new Aplicacoes()
            {
                Valor = 1000,
                Rentabilidade_Mes = 1.5
            };

            double lucroTotal = lucroRepo.CalcularLucroTotal(aplicacao, 20);

            double totalIR = lucroRepo.CalcularValorIR(20, lucroTotal);

            Assert.Equal(valorEsperado.ToString("C"), totalIR.ToString("C"));
        }

        [Fact]
        public void CalculoDeIR_AplicacaoComMaisDeDoisAnos_Retorna15DoLucro()
        {
            double valorEsperado = 84.462;
            LucroRepo lucroRepo = new LucroRepo();

            Aplicacoes aplicacao = new Aplicacoes()
            {
                Valor = 1000,
                Rentabilidade_Mes = 1.5
            };

            double lucroTotal = lucroRepo.CalcularLucroTotal(aplicacao, 30);

            double totalIR = lucroRepo.CalcularValorIR(30, lucroTotal);

            Assert.Equal(valorEsperado.ToString("C"), totalIR.ToString("C"));
        }

        [Fact]
        public void ValidacaoValorAplicacao_ValorMenorQueZero_RetornaZero()
        {
            Controllers.Aplicacao.Comunicacao comunicacao = new Controllers.Aplicacao.Comunicacao();

            double resultado = comunicacao.ColetarValidarValorAplicacao("-546.80");

            Assert.Equal(0, resultado);
        }

        [Fact]
        public void ValidacaoValorAplicacao_ValorIgualAZero_RetornaZero()
        {
            Controllers.Aplicacao.Comunicacao comunicacao = new Controllers.Aplicacao.Comunicacao();

            double resultado = comunicacao.ColetarValidarValorAplicacao("0");

            Assert.Equal(0, resultado);
        }

        [Fact]
        public void ValidacaoValorAplicacao_ValorMaiorQueZero_RetornaValor()
        {
            Controllers.Aplicacao.Comunicacao comunicacao = new Controllers.Aplicacao.Comunicacao();

            double resultado = comunicacao.ColetarValidarValorAplicacao("158.45");

            Assert.Equal(158.45, resultado);
        }
    }
}
