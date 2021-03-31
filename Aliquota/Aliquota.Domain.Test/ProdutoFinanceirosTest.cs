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
    public class ProdutoFinanceirosTest
    {
        public ServiceCollection Services { get; private set; }
        public ServiceProvider ServiceProvider { get; protected set; }

        Guid PRODUTO_ID = Guid.Parse("F47BB53B-C9BE-48C9-8B77-71821D777E90");

        public ProdutoFinanceirosTest()
        {
            Services = new ServiceCollection();

            Services.AddDbContext<AliquotaContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"),
                ServiceLifetime.Scoped,
                ServiceLifetime.Scoped);

            ServiceProvider = Services.BuildServiceProvider();
        }

        [Fact]
        public void ProdutoFinanceiro_Cadastro()
        {
            var context = ServiceProvider.GetService<AliquotaContext>();
            var produtoRepositorio = new ProdutoFinanceiroRepository(context);
            var aplicacaoRepositorio = new AplicacaoRepository(context);

            var _unitOfWork = new UnitOfWork(context, aplicacaoRepositorio, produtoRepositorio);

            var produtoService = new ProdutoService(_unitOfWork);

            produtoService.Add(new ProdutoFinanceiro() {Id = PRODUTO_ID, Nome = "Teste 1", Cotacao = (decimal)1.234 });

            var result = produtoService.List().Result;

            var model = Assert.IsAssignableFrom<IEnumerable<ProdutoFinanceiro>>(result);
            Assert.Single(model);
        }

        [Fact]
        public void ProdutoFinanceiro_Busca()
        {
            var context = ServiceProvider.GetService<AliquotaContext>();
            var produtoRepositorio = new ProdutoFinanceiroRepository(context);
            var aplicacaoRepositorio = new AplicacaoRepository(context);

            var _unitOfWork = new UnitOfWork(context, aplicacaoRepositorio, produtoRepositorio);

            var produtoService = new ProdutoService(_unitOfWork);

            var produto = produtoService.Find(PRODUTO_ID).Result;

            Assert.Equal((decimal)1.234, produto.Cotacao);
        }
    }
}
