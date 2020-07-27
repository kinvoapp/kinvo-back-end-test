using Aliquota.Domain.Entities;
using Aliquota.Domain.Repository;
using Aliquota.Domain.Services;
using Aliquota.Domain.Services.Interfaces;
using Aliquota.Repository.Context;
using Aliquota.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Aliquota.Domain.Test.Investimento
{
    public class ProdutoAplicacaoTest
    {
        private readonly IProdutoService _produtoService;
        private readonly IAplicacaoRepository _aplicacaoRepository;

        public ProdutoAplicacaoTest()
        {
            var builder = new DbContextOptionsBuilder<InvestimentoDbContext>().UseInMemoryDatabase("InMemoryDatabase");
            var dbContext = new InvestimentoDbContext(builder.Options);
            _aplicacaoRepository = new AplicacaoRepository(dbContext);
            _produtoService = new ProdutoService(_aplicacaoRepository);
        }

        [Fact]
        public void DeveFazerUmaAplicacaoComSucesso()
        {
            Aplicacao aplicacao = Aplicacao.Criar(100.0M, DateTime.Now);
            
            Assert.NotNull(_produtoService.Aplicar(aplicacao));
            Assert.Equal(aplicacao.Valor, aplicacao.ValorCorrigido);
            Assert.True(!aplicacao.Resgatado);
        }

        [Fact]
        public void DeveFazerUmaAplicacaoComErroQuantoValorIgualAZero()
        {
            var aplicacao = Aplicacao.Criar(0, DateTime.Now);

            Assert.Throws<Exception>(() => _produtoService.Aplicar(aplicacao));
        }

        [Fact]
        public void DeveFazerUmaAplicacaoComErroQuantoValorMenorQueZero()
        {
            var aplicacao = Aplicacao.Criar(-1, DateTime.Now);

            Assert.Throws<Exception>(() => _produtoService.Aplicar(aplicacao));
        }
    }
}
