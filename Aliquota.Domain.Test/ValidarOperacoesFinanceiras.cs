using Aliquota.API.Controllers;
using Aliquota.API.Helper;
using Aliquota.Domain.AggregatesModel.AplicacaoAggregate;
using Aliquota.Domain.AggregatesModel.ProdutoFinanceiroAggregate;
using Aliquota.Domain.AggregatesModel.Usuario;
using Aliquota.Infrastructure;
using Aliquota.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class ValidarOperacoesFinanceiras
    {
        private AliquotaContext context = new AliquotaContext(new DbContextOptionsBuilder<AliquotaContext>().UseInMemoryDatabase("DbTeste").Options);
        
        [Theory(DisplayName = "Valor de resgate de aplicação é correto.")]
        [InlineData(223.52, 100, 10)]
        [InlineData(274.28, 100, 12)]
        [InlineData(821.25, 100, 24)]
        public void ValidarValorDeResgate(double resultadoEsperado, double valorInicialDeAplicacao, int tempoDaAplicacaoEmMeses)
        {
            Aplicacao aplicacao = new Aplicacao(valorInicialDeAplicacao, 1, 1);
            AplicacaoDomain aplicacaoDomain = new AplicacaoDomain(aplicacao);

            var mockDateTime = new Mock<TimeProvider>();
            mockDateTime.Setup(o => o.UtcNow).Returns(DateTime.UtcNow.AddMonths(tempoDaAplicacaoEmMeses));
            TimeProvider.Current = mockDateTime.Object;

            var dataResgate = TimeProvider.Current.UtcNow;
            TimeProvider.ResetToDefault();

            var valorResgate = aplicacaoDomain.CalcularValorAResgatar(10, dataResgate);
            Assert.Equal(resultadoEsperado, Math.Round(valorResgate, 2));
        }

        [Theory(DisplayName = "Aplicacao com valor inicial inválido.")]
        [InlineData(0)]
        [InlineData(-10)]
        public void AplicacaoValorInicialInvalido(double valorInicial)
        {
            var exception = Assert.Throws<Exception>(() => new Aplicacao(valorInicial, 1, 1));
            Assert.Equal("Valor inicial de investimento é inválido. O valor deve ser maior que zero.", exception.Message);

        }

        [Fact(DisplayName ="Resgate com data invalida")]
        public void ResgateDeAplicacaoComDataInvalida()
        {
            Aplicacao aplicacao = new Aplicacao(100, 1, 1);
            AplicacaoDomain aplicacaoDomain = new AplicacaoDomain(aplicacao);

            var mockDateTime = new Mock<TimeProvider>();
            mockDateTime.Setup(o => o.UtcNow).Returns(DateTime.UtcNow.AddMinutes(-30));
            TimeProvider.Current = mockDateTime.Object;

            var dataResgate = TimeProvider.Current.UtcNow;
            TimeProvider.ResetToDefault();

            var exception = Assert.Throws<Exception>(() => aplicacaoDomain.RealizarResgate(10, dataResgate));
            Assert.Equal("A data de resgate da aplicação é invalida. A data de resgate não pode ser anterior a data inicial da aplicação.", exception.Message);
        }
    }
}
