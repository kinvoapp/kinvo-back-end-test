using System;
using System.Threading.Tasks;
using Aliquota.Core.DomainObjects;
using Aliquota.Domain.Models;
using Xunit;

namespace Aliquota.Domain.Tests
{
    public class ProdutoFinanceiroTests
    {
        [Trait("Categoria", "Produto Financeiro")]
        [Fact(DisplayName = "Deve criar uma instância válida de um Produto Financeiro")]
        public void ProdutoFinanceiro_Constructor_DeveCriarInstanciaValidaDeProdutoFinanceiro()
        {
            var (aplicacao, dataAplicacao, lucro, dataResgate) = (1000D, new DateTime(2021, 01, 01), 10, new DateTime(2021, 02, 01));

            var produtoFinanceiro = CriarProdutoFinanceiro(aplicacao: aplicacao, dataAplicacao: dataAplicacao, lucro: lucro, dataResgate: dataResgate);

            Assert.Equal(aplicacao, produtoFinanceiro.Aplicacao);
            Assert.Equal(dataAplicacao, produtoFinanceiro.DataAplicacao);
        }

        [Trait("Categoria", "Produto Financeiro")]
        [Fact(DisplayName = "Deve lançar DomainException se a aplicação for menor ou igual a zero")]
        public void ProdutoFinanceiro_Constructor_DeveLancarDomainExceptionSeAplicacaoForMenorOuIgualAhZero()
        {
            var ex = Assert.Throws<DomainException>(() => CriarProdutoFinanceiro(aplicacao: -1));

            Assert.Equal("A aplicação não pode ser menor ou igual a zero", ex.Message);
        }

        [Trait("Categoria", "Produto Financeiro")]
        [Fact(DisplayName = "Constructor deve lançar DomainException quando receber uma data de resgate anterior à data de aplicação")]
        public void ProdutoFinanceiro_Constructor_DeveLancarExcecaoQuandoDataResgateEhAnteriorADataAplicacao()
        {
            var dataAplicacao = new DateTime(2021, 02, 01);
            var dataResgate = new DateTime(2021, 01, 01);

            var ex = Assert.Throws<DomainException>(() => CriarProdutoFinanceiro(dataAplicacao: dataAplicacao, dataResgate: dataResgate));

            Assert.Equal("A Data de Resgate não pode ser menor que a Data de Aplicação", ex.Message);
        }

        private static ProdutoFinanceiro CriarProdutoFinanceiro(double aplicacao = 1000, DateTime? dataAplicacao = null, double lucro = 10, DateTime? dataResgate = null)
        {
            dataAplicacao ??= new DateTime(2021, 01, 01);
            dataResgate ??= new DateTime(2021, 02, 01);

            return new ProdutoFinanceiro(aplicacao, dataAplicacao.Value, lucro, dataResgate.Value);
        }
    }
}
