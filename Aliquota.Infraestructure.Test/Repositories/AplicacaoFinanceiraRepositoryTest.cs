using Aliquota.Infraestructure.DBConfiguration;
using Aliquota.Infraestructure.Interfaces.Repositories.Domain;
using Aliquota.Infraestructure.Repositories;
using Aliquota.Infraestructure.Test.Builders;
using Aliquota.Infraestructure.Test.DBConfiguration;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;
using Xunit;

namespace Aliquota.Domain.Test.Services
{
    public class AplicacaoFinanceiraRepositoryTest : IDisposable
    {
        private readonly ApplicationContext dbContext;
        private readonly IDbContextTransaction transaction;

        private readonly IAplicacaoFinanceiraRepository aplicacaoRepository;
        private readonly AplicacaoFinanceiraBuilder builder;

        public AplicacaoFinanceiraRepositoryTest()
        {
            dbContext = new EntityFrameworkConnection().DataBaseConfiguration();
            aplicacaoRepository = new AplicacaoFinanceiraRepository(dbContext);
            builder = new AplicacaoFinanceiraBuilder();
            transaction = dbContext.Database.BeginTransaction();
        }

        public void Dispose()
        {
            transaction.Rollback();
        }

        [Fact]
        public void GetAll()
        {
            var aplicacao = aplicacaoRepository.Add(builder.CriarAplicacaoFinanceira());
            var resultado = aplicacaoRepository.GetAll();
            Assert.Equal(resultado.OrderBy(u => u.Id).LastOrDefault().Id, aplicacao.Id);
        }

        [Fact]
        public void GetById()
        {
            var aplicacao = aplicacaoRepository.Add(builder.CriarAplicacaoFinanceira());
            var resultado = aplicacaoRepository.GetById(aplicacao.Id);
            Assert.Equal(resultado.Id, aplicacao.Id);
        }

        [Fact]
        public void Add()
        {
            var resultado = aplicacaoRepository.Add(builder.CriarAplicacaoFinanceira());
            Assert.True(resultado.Id > 0);
        }

        [Theory]
        [InlineData("2021-11-15")]
        public void Update(string dataResgate)
        {
            var inserido = aplicacaoRepository.Add(builder.CriarAplicacaoFinanceira());
            inserido.DataResgate = DateTime.Parse(dataResgate);

            var resultado = aplicacaoRepository.Update(inserido);
            Assert.Equal(1, resultado);
        }

        [Fact]
        public void Remove()
        {
            var inserido = aplicacaoRepository.Add(builder.CriarAplicacaoFinanceira());
            var resultado = aplicacaoRepository.Remove(inserido.Id);
            Assert.True(resultado);
        }

        [Fact]
        public void RemoveObj()
        {
            var inserido = aplicacaoRepository.Add(builder.CriarAplicacaoFinanceira());
            var resultado = aplicacaoRepository.Remove(inserido);
            Assert.Equal(1, resultado);
        }
    }
}
