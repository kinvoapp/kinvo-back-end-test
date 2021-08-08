using Aliquota.Domain.Models;
using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class ProdutoFinanceiroLucro
    {
        [Theory]
        [InlineData(25.20,210,"2021-04-01",3)]
        public void CalculaLucroEstimadoComBaseNoMesAtualQuandoNaoHouverDataDeResgate(double valorEsperado,double valorAplicado,DateTime dataAplicacao,double porcentagemProduto)
        {
            var produtoFinanceiro = new ProdutoFinanceiro
            {
                ValorAplicado=valorAplicado,
                DataAplicacao=dataAplicacao,
                TipoProdutoFinanceiro= new TipoProdutoFinanceiro
                {
                    PorcentagemLucro = porcentagemProduto
                }
            };
            Assert.Equal(valorEsperado, produtoFinanceiro.Lucro);
        }

        [Theory]
        [InlineData(18.90, 210,3,"2021-04-01","2021-07-07")]
        public void CalculaLucroBaseadoNaDataDeResgate(double valorEsperado, double valorAplicado, double porcentagemProduto, DateTime dataAplicacao, DateTime dataResgate)
        {
            var produtoFinanceiro = new ProdutoFinanceiro
            {
                ValorAplicado = valorAplicado,
                DataAplicacao = dataAplicacao,
                DataResgate = dataResgate,
                TipoProdutoFinanceiro = new TipoProdutoFinanceiro
                {
                    PorcentagemLucro = porcentagemProduto
                }
            };
            Assert.Equal(valorEsperado, produtoFinanceiro.Lucro);
        }
    }
}
