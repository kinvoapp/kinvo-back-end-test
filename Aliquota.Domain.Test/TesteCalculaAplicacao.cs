using Aliquota.Domain.Business;
using Aliquota.Domain.Models;
using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class TesteCalculaAplicacao
    {


        [Theory]
        [InlineData(100, 200, 100)]
        [InlineData(100, 99, -1)]
        [InlineData(50, 125, 75)]
        [InlineData(307.52, 102.3, -205.22)]
        [InlineData(0, 1000, 0)]
        public void CalculaAplicacaoShouldWorkLucroBruto(decimal valorInicial, decimal valorFinal, decimal lucroBrutoEsperado)
        {
            CalculaAplicacao calculaAplicacao = new CalculaAplicacao();
            decimal lucroBruto = calculaAplicacao.CalculaLucroBruto(valorInicial, valorFinal);
            Assert.Equal(lucroBrutoEsperado, lucroBruto);
        }

        [Theory]
        [InlineData(100, 200, 100)]
        [InlineData(50, 125, 75)]
        [InlineData(307.52, 102.3, -205.22)]
        [InlineData(0, 300, 300)]
        public void CalculaAplicacaoShouldWorkLucroLiquido(decimal valorImpostoRenda, decimal lucroBruto, decimal lucroLiquidoEsperado)
        {
            CalculaAplicacao calculaAplicacao = new CalculaAplicacao();
            valorImpostoRenda = calculaAplicacao.CalculaLucroLiquido(valorImpostoRenda, lucroBruto);
            Assert.Equal(lucroLiquidoEsperado, valorImpostoRenda);
        }

        [Theory]
        [InlineData("2021-03-23", "2021-03-23", 100, 22.5)]
        [InlineData("2021-03-23", "2021-03-24", 100, 22.5)]
        [InlineData("2021-03-23", "2022-03-22", 100, 22.5)]
        [InlineData("2021-03-23", "2022-03-23", 100, 18.5)]
        [InlineData("2021-03-23", "2022-03-24", 100, 18.5)]
        [InlineData("2021-03-23", "2023-02-24", 100, 18.5)]
        [InlineData("2021-03-23", "2023-03-22", 100, 18.5)]
        [InlineData("2021-03-23", "2023-03-23", 100, 18.5)]
        [InlineData("2021-03-23", "2023-03-24", 100, 15)]
        [InlineData("2021-03-23", "2023-04-24", 100, 15)]
        [InlineData("2021-03-23", "2025-04-24", 100, 15)]
        public void CalculaAplicacaoShouldWorkImpostoRenda(string dataAplicacao, string dataRetirada, decimal lucroBruto, decimal valorImpostoRendaEsperado)
        {
            DateTime dataInicio = DateTime.Parse(dataAplicacao);
            DateTime dataTermino = DateTime.Parse(dataRetirada);
            CalculaAplicacao calculaAplicacao = new CalculaAplicacao();
            decimal valorImpostoRenda = calculaAplicacao.CalculaImpostoRenda(dataInicio, dataTermino, lucroBruto);
            Assert.Equal(valorImpostoRendaEsperado, valorImpostoRenda);
        }

    }
}
