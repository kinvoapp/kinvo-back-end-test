using System;
using Xunit;
using Aliquota.Domain.Models;
using System.Linq;

namespace Aliquota.Domain.Test
{
    public class Test
    {
        [Fact]
        public void TestAliquotaQuinze()
        {
            Cliente cliente = new Cliente(new Guid(),"Nome Teste", "12345678900", null);
            DateTime dataAplicacao = DateTime.Today.AddYears(-3);
            DateTime dataResgate = DateTime.Today;
            ProdutoFinanceiro produto = new ProdutoFinanceiro(new Guid(), cliente,100,dataAplicacao, dataResgate);
            Assert.Equal(new Decimal(15), produto.AliquotaImposto);
        }

        [Fact]
        public void TestAliquotaVinteDoisEMeio()
        {
            Cliente cliente = new Cliente(new Guid(),"Nome Teste", "12345678900", null);
            DateTime dataAplicacao2 = DateTime.Today.AddMonths(-6);
            DateTime dataResgate2 = DateTime.Today;
            ProdutoFinanceiro produto = new ProdutoFinanceiro(new Guid(), cliente,100,dataAplicacao2, dataResgate2);
            Assert.Equal(new Decimal(22.5), produto.AliquotaImposto);
        }

        [Fact]
        public void TestAliquotaDezoitoEMeio()
        {
            Cliente cliente = new Cliente(new Guid(),"Nome Teste", "12345678900", null);
            DateTime dataAplicacao = DateTime.Today.AddMonths(-18);
            DateTime dataResgate = DateTime.Today;
            ProdutoFinanceiro produto = new ProdutoFinanceiro(new Guid(), cliente,100,dataAplicacao, dataResgate);
            Assert.Equal(new Decimal(18.5), produto.AliquotaImposto);
        }

        [Fact]
        public void TestAdicionarProduto()
        {
            Cliente cliente = new Cliente(new Guid(),"Nome Teste", "12345678900", null);
            DateTime dataAplicacao = DateTime.Today.AddMonths(-18);
            DateTime dataResgate = DateTime.Today;
            ProdutoFinanceiro produto = new ProdutoFinanceiro(new Guid(), cliente,100,dataAplicacao, dataResgate);
            Assert.Empty(cliente.ProdutosFinanceiros);
            cliente.AdicionarProdutoFinanceiro(produto);
            Assert.Single(cliente.ProdutosFinanceiros);
        }
    }
}
