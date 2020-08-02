using System;
using Xunit;
using Aliquota.Domain.Model;
namespace Aliquota.Test
{

    public class TesteUnidadeProduto
    {
        [Fact]
        public void TesteCriarProdutoIdInvalido()
        {

            _ = Assert.Throws<ArgumentException>(() =>
              new Produto(
                  0
                  , "Tesouro Selic"
                  , 1.0M
                  , DateTime.Now.AddDays(2)));
        }
        [Fact]
        public void TesteCriarProdutoNomeVazio()
        {

            _ = Assert.Throws<ArgumentException>(() =>
              new Produto(
                  1
                  , ""
                  , 1.0M
                  , DateTime.Now.AddDays(2)));
        }
        [Fact]
        public void TesteCriarProdutoTaxaInvalido()
        {

            _ = Assert.Throws<ArgumentException>(() =>
              new Produto(
                  1
                  , "Tesouro Selic"
                  , -1.0M
                  , DateTime.Now.AddDays(2)));
        }
        [Fact]
        public void TesteCriarProdutoVencimentoInvalido()
        {

            _ = Assert.Throws<ArgumentException>(() =>
              new Produto(
                  1
                  , "Tesouro Selic"
                  , 1.0M
                  , DateTime.Now.AddDays(-1)));
        }
    }
}
