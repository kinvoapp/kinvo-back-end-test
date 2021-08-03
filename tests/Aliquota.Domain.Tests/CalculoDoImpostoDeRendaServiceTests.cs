using System;
using System.Threading.Tasks;
using Aliquota.Core.DomainObjects;
using Aliquota.Domain.Interfaces;
using Aliquota.Domain.Models;
using Aliquota.Domain.Services;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace Aliquota.Domain.Tests
{
    public class CalculoDoImpostoDeRendaServiceTests
    {

        [Trait("Categoria", "Cálculo do Imposto de Renda")]
        [Fact(DisplayName = "Deve chamar ObterPeloId do repositório com o Id passado")]
        public async Task CalculoDoImpostoDeRendaService_Calcular_DeveChamarObterPeloIdComIdFornecido()
        {
            var mock = new AutoMocker();
            var produtoFinanceiroRepositoryMock = mock.GetMock<IProdutoFinanceiroRepository>();

            var produtoFinanceiro = CriarProdutoFinanceiro();
            var produtoFinanceiroId = Guid.NewGuid();

            DefinirRetornoDoMetodoObterPeloId(produtoFinanceiroRepositoryMock, produtoFinanceiroId, produtoFinanceiro);

            var sut = mock.CreateInstance<CalculoDoImpostoDeRendaService>();

            await sut.Calcular(produtoFinanceiroId);

            produtoFinanceiroRepositoryMock.Verify(r => r.ObterPeloId(produtoFinanceiroId), Times.Once);
        }

        [Trait("Categoria", "Cálculo do Imposto de Renda")]
        [Fact(DisplayName = "Deve lançar DomainException se ObterPeloId retornar null")]
        public async Task CalculoDoImpostoDeRendaService_Calcular_DeveLancarExceptionSeObterPeloIdRetornarNull()
        {
            var mock = new AutoMocker();
            var produtoFinanceiroRepositoryMock = mock.GetMock<IProdutoFinanceiroRepository>();

            var sut = mock.CreateInstance<CalculoDoImpostoDeRendaService>();

            var ex = await Assert.ThrowsAsync<DomainException>(() => sut.Calcular(Guid.NewGuid()));

            Assert.Equal("Produto financeiro não encontrado", ex.Message);
        }

        [Trait("Categoria", "Cálculo do Imposto de Renda")]
        [Theory(DisplayName = "Deve calcular o IR com base no tempo de aplicação")]
        [InlineData("2020-01-01", "2020-12-01", 100, 22.5)]
        [InlineData("2020-01-01", "2021-01-01", 100, 18.5)]
        [InlineData("2019-01-01", "2021-01-01", 100, 15)]
        public async Task CalculoDoImpostoDeRendaService_Calcular_DeveCalcularIRComBaseNoTempoDeAplicacao(string dataAplicacao, string dataResgate, double lucro, double impostoDeRendaEsperado)
        {
            var mock = new AutoMocker();
            var produtoFinanceiroRepositoryMock = mock.GetMock<IProdutoFinanceiroRepository>();

            var produtoFinanceiro = CriarProdutoFinanceiro(dataAplicacao: dataAplicacao, lucro: lucro, dataResgate: dataResgate);

            var produtoFinanceiroId = Guid.NewGuid();

            DefinirRetornoDoMetodoObterPeloId(produtoFinanceiroRepositoryMock, produtoFinanceiroId, produtoFinanceiro);

            var sut = mock.CreateInstance<CalculoDoImpostoDeRendaService>();

            var impostoDeRenda = await sut.Calcular(produtoFinanceiroId);

            Assert.Equal(impostoDeRendaEsperado, impostoDeRenda);
        }

        private static ProdutoFinanceiro CriarProdutoFinanceiro(string dataAplicacao = "2020-01-01", double aplicacao = 1000D, double lucro = 10D, string dataResgate = "2021-01-01")
        {
            return new ProdutoFinanceiro(aplicacao, DateTime.Parse(dataAplicacao), lucro, DateTime.Parse(dataResgate));
        }

        private static void DefinirRetornoDoMetodoObterPeloId(Mock<IProdutoFinanceiroRepository> mock, Guid id, ProdutoFinanceiro retorno)
        {
            mock.Setup(r => r.ObterPeloId(id)).ReturnsAsync(retorno);
        }
    }
}