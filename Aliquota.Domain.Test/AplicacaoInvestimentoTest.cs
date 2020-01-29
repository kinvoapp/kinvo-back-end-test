using Aliquota.Domain.Entities;
using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class AplicacaoInvestimentoTest
    {
        readonly CarteiraInvestimentos carteiraInvestimentos = new CarteiraInvestimentos();

        [Fact]
        public void AdicionarCarteiraInvestimento()
        {
            carteiraInvestimentos.IdCarteiraInvestimentos = 1;
            carteiraInvestimentos.ProdutoFinanceiro = new ProdutoFinanceiro();
            carteiraInvestimentos.ProdutoFinanceiro.IdProdutoFinanceiro = 1;
            carteiraInvestimentos.ProdutoFinanceiro.DescricaoProdutoFinanceiro = "Tesouro Direto";
            carteiraInvestimentos.DataAplicado = DateTime.Now.Date;
            carteiraInvestimentos.ValorAplicado = 5300.91m;

            //var carteiraInvestimentosService = new CarteiraInvestimentosService(carteiraInvestimentos);
            //carteiraInvestimentosService.AdicionarCarteiraInvestimentos("Tesouro Direto", DateTime.Now.Date, 5300.91m);

            Assert.Equal(1, carteiraInvestimentos.IdCarteiraInvestimentos);
            Assert.Equal(1, carteiraInvestimentos.ProdutoFinanceiro.IdProdutoFinanceiro);
            Assert.Equal("Tesouro Direto", carteiraInvestimentos.ProdutoFinanceiro.DescricaoProdutoFinanceiro);
            Assert.Equal(DateTime.Now.Date, carteiraInvestimentos.DataAplicado);
            Assert.Equal(5300.91m, carteiraInvestimentos.ValorAplicado);
        }

        [Fact]
        public void ResgatarCarteiraInvestimento()
        {
            carteiraInvestimentos.IdCarteiraInvestimentos = 1;
            carteiraInvestimentos.DataResgate = DateTime.Now.Date;
            carteiraInvestimentos.ValorBruto = 6000.00m;
            carteiraInvestimentos.ValorLiquido = carteiraInvestimentos.ValorBruto - carteiraInvestimentos.ValorIR;s
        }
    }
}
