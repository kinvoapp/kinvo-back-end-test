using System;
using Aliquota.Domain.Model;
using Xunit;

namespace Aliquota.Test
{
    public class TesteUnidadeInvestimento
    {

        [Fact]
        public void TesteCriacaoInvestimentoValorInvalido()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Investimento(Convert.ToDecimal(-10.0M));
            });
        }
        [Fact]
        public void TesteCriacaoInvestimentoComZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Investimento(Convert.ToDecimal(0.0M));
            });
            var va = new Investimento();

        }

        [Fact]
        public void TesteIntegracaoObterIR22_5()
        {
            var produto = new Produto(1, "Tesouro Selic", 1.0M, DateTime.Now.AddYears(2));

            var carteira = new Carteira("Luiz Eduardo");

            var investimento = new Investimento(Guid.NewGuid(), 100M, produto.Id, carteira.Id);
            // Preencher Relacionamento
            investimento.Produto = produto;
            investimento.Carteira = carteira;

            var IR = investimento.RetornarImpostoDeRendaPorAno(DateTime.Now.AddYears(1));
            Assert.Equal(0.22603411996155000M, IR);// Aproximado falhando
        }

        [Fact]
        public void TesteIntegracaoObterIR18_5()
        {
            var produto = new Produto(1, "Tesouro Selic", 1.0M, DateTime.Now.AddYears(2));

            var carteira = new Carteira("Luiz Eduardo");

            var investimento = new Investimento(Guid.NewGuid(), 100M, produto.Id, carteira.Id);
            // Preencher Relacionamento
            investimento.Produto = produto;
            investimento.Carteira = carteira;

            var IR = investimento.RetornarImpostoDeRendaPorAno(DateTime.Now.AddYears(1).AddMonths(6));
            Assert.Equal(0.27947438847516000M, IR); // Aproximado falhando
        }

        [Fact]
        public void TesteIntegracaoObterIR15()
        {
            var produto = new Produto(1, "Tesouro Selic", 1.0M, DateTime.Now.AddYears(2));

            var carteira = new Carteira("Luiz Eduardo");

            var investimento = new Investimento(Guid.NewGuid(), 100M, produto.Id, carteira.Id);
            // Preencher Relacionamento
            investimento.Produto = produto;
            investimento.Carteira = carteira;

            var IR = investimento.RetornarImpostoDeRendaPorAno(DateTime.Now.AddYears(2).AddMonths(6));
            Assert.Equal(0.3795666921597000M, IR);// Aproximado falhando
        }
        [Fact]
        public void TesteIntegracaoObterValor()
        {
            var produto = new Produto(1, "Tesouro Selic", 1.0M, DateTime.Now.AddYears(2));

            var carteira = new Carteira("Luiz Eduardo");

            var investimento = new Investimento(Guid.NewGuid(), 100M, produto.Id, carteira.Id);
            // Preencher Relacionamento
            investimento.Produto = produto;
            investimento.Carteira = carteira;

            investimento.RetornarInvestimentoParaCarteira(DateTime.Now.AddYears(1));
            Assert.Equal(100.78865410177112503726883524M, carteira.Valor);
        }
    }
}
