using Aliquota.Domain.Data;
using Aliquota.Domain.Data.Interfaces;
using Aliquota.Domain.Models;
using Aliquota.Domain.Negocio;
using Aliquota.Domain.Negocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class ResgateTest : IDisposable
    {
        public ServiceCollection Services { get; private set; }
        public ServiceProvider ServiceProvider { get; protected set; }

        AliquotaContext _context;

        Guid PRODUTO01_ID = Guid.Parse("F47BB53B-C9BE-48C9-8B77-71821D777E90");

        public ResgateTest()
        {
            Services = new ServiceCollection();
            ServiceProvider = Services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<AliquotaContext>().UseInMemoryDatabase(databaseName: "InMemoryDb").UseInternalServiceProvider(ServiceProvider);
            
            _context = new AliquotaContext(builder.Options);
            _context.ProdutosFinanceiros.Add(new ProdutoFinanceiro() { Id = PRODUTO01_ID, Nome = "Teste 1", Cotacao = (decimal)1000 });
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        [Fact]
        public void Resgate_Validacao_DeveRetornarAlicotaParaAplicacaoUmAno()
        {
            var produtoRepositorio = new ProdutoFinanceiroRepository(_context);
            var aplicacaoRepositorio = new AplicacaoRepository(_context);

            var _unitOfWork = new UnitOfWork(_context, aplicacaoRepositorio, produtoRepositorio);

            var aplicacaoService = new AplicacaoService(_unitOfWork);
            var produtoService = new ProdutoService(_unitOfWork);

            ProdutoFinanceiro produtoFinanceiro = produtoService.Find(PRODUTO01_ID).Result;

            Aplicacao aplicacao = new Aplicacao() { DataAplicacao = DateTime.Now.Date.AddDays(-360), ProdutoFinanceiro = produtoFinanceiro, ProdutoFinanceiroId = produtoFinanceiro.Id, ValorAplicado = 0, Quantidade = 0 };

            var result = aplicacaoService.ObterAlicotaImposto(aplicacao, DateTime.Now.Date);
            Assert.Equal((decimal)22.5, result, 1);
        }

        [Fact]
        public void Resgate_Validacao_DeveRetornarAlicotaParaAplicacaoDoisAnos()
        {
            var produtoRepositorio = new ProdutoFinanceiroRepository(_context);
            var aplicacaoRepositorio = new AplicacaoRepository(_context);

            var _unitOfWork = new UnitOfWork(_context, aplicacaoRepositorio, produtoRepositorio);

            var aplicacaoService = new AplicacaoService(_unitOfWork);
            var produtoService = new ProdutoService(_unitOfWork);

            ProdutoFinanceiro produtoFinanceiro = produtoService.Find(PRODUTO01_ID).Result;

            Aplicacao aplicacao = new Aplicacao() { DataAplicacao = DateTime.Now.Date.AddDays(-360 * 2), ProdutoFinanceiro = produtoFinanceiro, ProdutoFinanceiroId = produtoFinanceiro.Id, ValorAplicado = 0, Quantidade = 0 };

            var result = aplicacaoService.ObterAlicotaImposto(aplicacao, DateTime.Now.Date);
            Assert.Equal((decimal)18.5, result, 1);
        }

        [Fact]
        public void Resgate_Validacao_DeveRetornarAlicotaParaAplicacaoAcimaDoisAnos()
        {
            var produtoRepositorio = new ProdutoFinanceiroRepository(_context);
            var aplicacaoRepositorio = new AplicacaoRepository(_context);

            var _unitOfWork = new UnitOfWork(_context, aplicacaoRepositorio, produtoRepositorio);

            var aplicacaoService = new AplicacaoService(_unitOfWork);
            var produtoService = new ProdutoService(_unitOfWork);

            ProdutoFinanceiro produtoFinanceiro = produtoService.Find(PRODUTO01_ID).Result;

            Aplicacao aplicacao = new Aplicacao() { DataAplicacao = DateTime.Now.Date.AddDays(-360 * 3), ProdutoFinanceiro = produtoFinanceiro, ProdutoFinanceiroId = produtoFinanceiro.Id, ValorAplicado = 0, Quantidade = 0 };

            var result = aplicacaoService.ObterAlicotaImposto(aplicacao, DateTime.Now.Date);
            Assert.Equal(result, (decimal)produtoFinanceiro.AliquotaDefault, 1);
        }

        [Fact]
        public void Resgate_Validacao_DeveRetornarImpostoZeroParaAplicacaoComPrejuizo()
        {
            var produtoRepositorio = new ProdutoFinanceiroRepository(_context);
            var aplicacaoRepositorio = new AplicacaoRepository(_context);

            var _unitOfWork = new UnitOfWork(_context, aplicacaoRepositorio, produtoRepositorio);

            var aplicacaoService = new AplicacaoService(_unitOfWork);
            var produtoService = new ProdutoService(_unitOfWork);

            ProdutoFinanceiro produtoFinanceiro = produtoService.Find(PRODUTO01_ID).Result;

            Aplicacao aplicacao = new Aplicacao() { DataAplicacao = DateTime.Now.Date.AddDays(-5), ProdutoFinanceiro = produtoFinanceiro, ProdutoFinanceiroId = produtoFinanceiro.Id, ValorAplicado = 2000, Quantidade = 2 };

            produtoFinanceiro.Cotacao = 500;
            produtoService.Edit(produtoFinanceiro);

            var result = aplicacaoService.ObterImpostoARecolher(aplicacao, DateTime.Now.Date);
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(5, 2000*0.225)]
        [InlineData(366, 2000*0.185)]
        [InlineData(365 * 2 + 1, 2000 * 0.15)]
        public void Resgate_Validacao_DeveRetornarImpostoCorretoParaAplicacaoComLucro(int diasAplicado, decimal esperado)
        {
            var produtoRepositorio = new ProdutoFinanceiroRepository(_context);
            var aplicacaoRepositorio = new AplicacaoRepository(_context);

            var _unitOfWork = new UnitOfWork(_context, aplicacaoRepositorio, produtoRepositorio);

            var aplicacaoService = new AplicacaoService(_unitOfWork);
            var produtoService = new ProdutoService(_unitOfWork);

            ProdutoFinanceiro produtoFinanceiro = produtoService.Find(PRODUTO01_ID).Result;

            Aplicacao aplicacao = new Aplicacao() { DataAplicacao = DateTime.Now.Date.AddDays(diasAplicado * -1), ProdutoFinanceiro = produtoFinanceiro, ProdutoFinanceiroId = produtoFinanceiro.Id, ValorAplicado = 2000, Quantidade = 2 };

            produtoFinanceiro.Cotacao = 2000;
            produtoService.Edit(produtoFinanceiro);

            var result = aplicacaoService.ObterImpostoARecolher(aplicacao, DateTime.Now.Date);
            Assert.Equal(esperado, result);
        }

        [Fact]
        public void Resgate_LancarExceptionQuandoDataResgateMenorDataAplicacao()
        {
            var context = ServiceProvider.GetService<AliquotaContext>();
            var produtoRepositorio = new ProdutoFinanceiroRepository(_context);
            var aplicacaoRepositorio = new AplicacaoRepository(_context);

            var _unitOfWork = new UnitOfWork(_context, aplicacaoRepositorio, produtoRepositorio);

            var aplicacaoService = new AplicacaoService(_unitOfWork);
            var produtoService = new ProdutoService(_unitOfWork);

            ProdutoFinanceiro produtoFinanceiro = produtoService.Find(PRODUTO01_ID).Result;

            Aplicacao aplicacao = new Aplicacao() { DataAplicacao = DateTime.Now, ProdutoFinanceiro = produtoFinanceiro, ProdutoFinanceiroId = produtoFinanceiro.Id, ValorAplicado = 1000, Quantidade = 1 };
            aplicacaoService.Add(aplicacao);
            Assert.Throws<ApplicationException>(() => aplicacaoService.Resgatar(aplicacao, DateTime.Now.AddDays(-1)));
        }
    }
}
