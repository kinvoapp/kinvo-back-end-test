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
    public class AplicacaoTest : IDisposable
    {
        public ServiceCollection Services { get; private set; }
        public ServiceProvider ServiceProvider { get; protected set; }

        AliquotaContext _context;

        Guid PRODUTO01_ID = Guid.Parse("F47BB53B-C9BE-48C9-8B77-71821D777E90");

        public AplicacaoTest()
        {
            Services = new ServiceCollection();
            ServiceProvider = Services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<AliquotaContext>().UseInMemoryDatabase(databaseName: "InMemoryDb").UseInternalServiceProvider(ServiceProvider);
            //Services.AddDbContext<AliquotaContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb").UseInternalServiceProvider(ServiceProvider));


            //_context = ServiceProvider.GetService<AliquotaContext>();
            _context = new AliquotaContext(builder.Options);
            _context.ProdutosFinanceiros.Add(new ProdutoFinanceiro() { Id = PRODUTO01_ID, Nome = "Teste 1", Cotacao = (decimal)1000 });
            _context.SaveChanges();
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        [Fact]
        public void Aplicacao_Validacao_NaoDeveValidarAplicacaoValorZero()
        {
            var produtoRepositorio = new ProdutoFinanceiroRepository(_context);
            var aplicacaoRepositorio = new AplicacaoRepository(_context);

            var _unitOfWork = new UnitOfWork(_context, aplicacaoRepositorio, produtoRepositorio);

            var aplicacaoService = new AplicacaoService(_unitOfWork);
            var produtoService = new ProdutoService(_unitOfWork);

            ProdutoFinanceiro produtoFinanceiro = produtoService.Find(PRODUTO01_ID).Result;

            Aplicacao aplicacao = new Aplicacao() { DataAplicacao = DateTime.Now, ProdutoFinanceiro = produtoFinanceiro, ProdutoFinanceiroId = produtoFinanceiro.Id, ValorAplicado = 0, Quantidade = 0 };

            var result = aplicacaoService.ValidarAplicacao(aplicacao);
            Assert.False(result);
        }

        [Fact]
        public void Aplicacao_Validacao_NaoDeveValidarResgateDataAnterior()
        {
            var produtoRepositorio = new ProdutoFinanceiroRepository(_context);
            var aplicacaoRepositorio = new AplicacaoRepository(_context);

            var _unitOfWork = new UnitOfWork(_context, aplicacaoRepositorio, produtoRepositorio);

            var aplicacaoService = new AplicacaoService(_unitOfWork);
            var produtoService = new ProdutoService(_unitOfWork);

            ProdutoFinanceiro produtoFinanceiro = produtoService.Find(PRODUTO01_ID).Result;

            Aplicacao aplicacao = new Aplicacao() { DataAplicacao = DateTime.Now, ProdutoFinanceiro = produtoFinanceiro, ProdutoFinanceiroId = produtoFinanceiro.Id, ValorAplicado = 0, Quantidade = 0 };

            var result = aplicacaoService.ValidarResgate(aplicacao, DateTime.Now.AddDays(-1));
            Assert.False(result);
        }

        [Fact]
        public void Aplicacao_Cadastro_LancarExceptionQuandoAplicacaoValorZero()
        {
            var context = ServiceProvider.GetService<AliquotaContext>();
            var produtoRepositorio = new ProdutoFinanceiroRepository(_context);
            var aplicacaoRepositorio = new AplicacaoRepository(_context);

            var _unitOfWork = new UnitOfWork(_context, aplicacaoRepositorio, produtoRepositorio);

            var aplicacaoService = new AplicacaoService(_unitOfWork);
            var produtoService = new ProdutoService(_unitOfWork);

            ProdutoFinanceiro produtoFinanceiro = produtoService.Find(PRODUTO01_ID).Result;

            Aplicacao aplicacao = new Aplicacao() { DataAplicacao = DateTime.Now, ProdutoFinanceiro = produtoFinanceiro, ProdutoFinanceiroId = produtoFinanceiro.Id, ValorAplicado = 0, Quantidade = 0 };
            Assert.Throws<ApplicationException>(() => aplicacaoService.Add(aplicacao));
        }

        [Fact]
        public void Aplicacao_Cadastro_DevePermitirAplicacaoValorMaiorQueZero()
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
            
        }

    }
}
