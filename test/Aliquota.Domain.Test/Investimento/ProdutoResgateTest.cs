using Aliquota.Domain.Entities;
using Aliquota.Domain.Repository;
using Aliquota.Domain.Services;
using Aliquota.Domain.Services.Interfaces;
using Aliquota.Repository.Context;
using Aliquota.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Aliquota.Domain.Test.Investimento
{
    public class ProdutoResgateTest
    {
        private readonly IProdutoService _produtoService;
        private readonly IAplicacaoRepository _aplicacaoRepository;
        private readonly InvestimentoDbContext _db;

        const double TaxaImpostoAte1Ano = 22.5;
        const double TaxaImpostoAte2Anos = 18.5;
        const double TaxaImpostoMaiorQue2Anos = 15;

        public ProdutoResgateTest()
        {
            var builder = new DbContextOptionsBuilder<InvestimentoDbContext>().UseInMemoryDatabase("InMemoryDatabase");
            _db = new InvestimentoDbContext(builder.Options);
            _aplicacaoRepository = new AplicacaoRepository(_db);
            _produtoService = new ProdutoService(_aplicacaoRepository);
        }

        [Theory]
        [InlineData(100.0, 102.02, TaxaImpostoAte1Ano, 1)]
        [InlineData(100.0, 104.08, TaxaImpostoAte2Anos, 2)]
        [InlineData(100.0, 108.32, TaxaImpostoMaiorQue2Anos, 4)]
        [InlineData(122.3, 132.48, TaxaImpostoMaiorQue2Anos, 4)]
        [InlineData(543.9, 566.08, TaxaImpostoAte2Anos, 2)]
        [InlineData(1298.25, 1324.45, TaxaImpostoAte1Ano, 1)]
        public void DeveFazerUmResgateComSucesso(decimal valorInvestido, decimal bruto, decimal taxaImposto, int anos)
        {
            var dataAplicaco = DateTime.Now;
            var dataResgate = dataAplicaco.AddYears(anos);
            var valorTaxado = Math.Round((taxaImposto / 100) * (bruto - valorInvestido), 2);
            var valorLiquido = Math.Round(bruto - valorTaxado, 2);

            Aplicacao aplicacao = _produtoService.Aplicar(Aplicacao.Criar(valorInvestido, dataAplicaco));;
            Resgate resgate = _produtoService.Resgatar(aplicacao, dataResgate);

            Assert.NotNull(resgate);
            Assert.Equal(bruto, resgate.ValorBruto);
            Assert.Equal(valorLiquido, resgate.ValorLiquido);
            Assert.Equal(valorTaxado, resgate.ImpostoRendaRecolhido);
            Assert.True(aplicacao.Resgatado);
        }

        [Fact]
        public void DeveDarErroQuandoResgateTerDataMenorQueAplicacao()
        {
            var dataAplicaco = DateTime.Now;
            var dataResgate = dataAplicaco.AddMinutes(-1);

            Aplicacao aplicacao = Aplicacao.Criar(100.0M, dataAplicaco);

            Assert.Throws<Exception>(() => _produtoService.Resgatar(aplicacao, dataResgate));
        }

        [Theory]
        [InlineData(2019)]
        [InlineData(2020)]
        [InlineData(2021)]
        [InlineData(2022)]
        [InlineData(2023)]
        [InlineData(2024)]
        public void DeveResgatarApenasDisponiveis(int anoResgate)
        {
            _produtoService.Aplicar(Aplicacao.Criar(100, new DateTime(2020, 01, 01, 0, 0, 0)));
            _produtoService.Aplicar(Aplicacao.Criar(100, new DateTime(2021, 01, 01, 0, 0, 0)));
            _produtoService.Aplicar(Aplicacao.Criar(100, new DateTime(2022, 01, 01, 0, 0, 0)));

            var dataResgate = new DateTime(anoResgate, 01, 01, 0, 0, 0);

            var resgates = _produtoService.ResgatarTodosDisponiveis(dataResgate).ToList();

            Assert.True(resgates.All(x => x.Aplicacao.Data < dataResgate));
        }
    }
}
