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
        public void CalculoDeIR_AplicacaoComMaisDeUmAno_Retorna225DoLucro()
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
        public void CalculoDeIR_AplicacaoComMaisDeDoisAnos_Retorna225DoLucro()
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
    }
}
