using Xunit;
using System;
using Aliquota.Domain.Models;
using Bogus;

namespace Aliquota.Domain.Tests
{
    [CollectionDefinition(nameof(ProdutoCollection))]
    public class ProdutoCollection : ICollectionFixture<ProdutoTestsFixture> { }

    public class ProdutoTestsFixture : IDisposable
    {

        public Produto GerarProdutoValido()
        {
            //var nomeFundo = new Faker().Company.CompanyName();

            //var produto = new Produto(Guid.NewGuid(), "Fundo XYZ", 12, true, DateTime.Now);

            var produto = new Faker<Produto>("pt_BR")
                .CustomInstantiator(f => new Produto(
                    Guid.NewGuid(),
                    f.Company.CompanyName(),
                    f.Random.Number(0,12),
                    true,
                    f.Date.Past(5, DateTime.Now.AddYears(-1))));

            return produto;
        }

        public Produto GerarProdutoInvalido()
        {
            // var produto = new Produto(Guid.NewGuid(), "Fund", 12, true, DateTime.Now);

            var produto = new Faker<Produto>("pt_BR")
                .CustomInstantiator(f => new Produto(
                    Guid.NewGuid(),
                    f.Lorem.Letter(),
                    f.Random.Number(0, 12),
                    true,
                    f.Date.Past(5, DateTime.Now.AddYears(-1))));

            return produto;
        }

        public void Dispose()
        {
            // 
        }
    }
}
