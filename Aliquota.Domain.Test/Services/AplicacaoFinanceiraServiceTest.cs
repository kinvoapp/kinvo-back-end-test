using Aliquota.Application.Interfaces.Services;
using Aliquota.Application.Services;
using System;
using Xunit;

namespace Aliquota.Domain.Test.Services
{
    public class AplicacaoFinanceiraServiceTest
    {
        private readonly IAplicacaoFinanceiraService aplicacaoService;
        private readonly AplicacaoFinanceiraBuilder builder;

        public AplicacaoFinanceiraServiceTest()
        {
            aplicacaoService = new AplicacaoFinanceiraService(null);
            builder = new AplicacaoFinanceiraBuilder();
        }

        [Fact]
        public void CalcularAliquotaIR()
        {
            var aplicacao = builder.CriarAplicacaoFinanceira();

            var resultado = aplicacaoService.CalcularAliquotaIR(aplicacao.DataAplicacao, aplicacao.DataResgate.Value);
            Assert.Equal(0.225, resultado);
        }

        [Fact]
        public void CalcularRendimentoBruto()
        {
            var resultado = aplicacaoService.CalcularRendimentoBruto(builder.CriarAplicacaoFinanceira());
            Assert.Equal(1004.94, resultado);
        }

        [Fact]
        public void CalcularImpostoDeRendaRecolhido()
        {
            var aplicacao = builder.CriarAplicacaoFinanceira();
            aplicacao.ValorRendimentoBruto = aplicacaoService.CalcularRendimentoBruto(aplicacao);

            var aliquota = aplicacaoService.CalcularAliquotaIR(aplicacao.DataAplicacao, aplicacao.DataResgate.Value);
            var resultado = aplicacaoService.CalcularImpostoDeRendaRecolhido(aplicacao, aliquota);
            Assert.Equal(1.11, resultado);
        }

        [Fact]
        public void CalcularRendimento()
        {
            var resultado = aplicacaoService.CalcularRendimento(builder.CriarAplicacaoFinanceira());
            Assert.Equal(1003.83, resultado.ValorRendimentoLiquido);
        }
    }
}
