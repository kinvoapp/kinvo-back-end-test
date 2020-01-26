using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Aliquota.Domain.Test
{
	public class TesteAplicacao
	{
		[Fact]
		public void Remove_Aplicacao()
		{
			var opcoes = new DbContextOptionsBuilder<ContextoInvestimento>()
				.UseInMemoryDatabase(databaseName: "Remove_Aplicacao")
				.Options;

			using (var contexto = new ContextoInvestimento(opcoes))
			{
				var servicoProduto = new ServicoProdutoFinanceiro(contexto);
				servicoProduto.Adicionar("CDB");

				var servicoCliente = new ServicoCliente(contexto);
				servicoCliente.Adicionar("João");

				var servicoAplicacao = new ServicoAplicacao(contexto);
				servicoAplicacao
					.Adicionar(2500.87m, servicoCliente.BuscaPorNome("João"), servicoProduto.BuscaPorNome("CDB"));

			}

			using (var contexto = new ContextoInvestimento(opcoes))
			{
				Aplicacao aplicacao = contexto.Aplicacoes.Include(a => a.Cliente).Include(a => a.ProdutoFinanceiro).Single();
				var servicoAplicacao = new ServicoAplicacao(contexto);
				servicoAplicacao.Remover(aplicacao);

				Assert.Equal(0, contexto.Aplicacoes.Count());
				
				contexto.Database.EnsureDeleted();
			}
		}

		[Fact]
		public void Adiciona_Aplicacao()
		{
			var opcoes = new DbContextOptionsBuilder<ContextoInvestimento>()
				.UseInMemoryDatabase(databaseName: "Adiciona_Aplicacao")
				.Options;

			using (var contexto = new ContextoInvestimento(opcoes))
			{
				var servicoProduto = new ServicoProdutoFinanceiro(contexto);
				servicoProduto.Adicionar("CDB");

				var servicoCliente = new ServicoCliente(contexto);
				servicoCliente.Adicionar("João");

				var servicoAplicacao = new ServicoAplicacao(contexto);
				servicoAplicacao
					.Adicionar(2500.87m, servicoCliente.BuscaPorNome("João"), servicoProduto.BuscaPorNome("CDB"));

			}

			using (var contexto = new ContextoInvestimento(opcoes))
			{
				Aplicacao aplicacao = contexto.Aplicacoes.Include(a => a.Cliente).Include(a => a.ProdutoFinanceiro).Single();

				Assert.Equal(1, contexto.Aplicacoes.Count());
				Assert.Equal(2500.87m, aplicacao.Valor);
				Assert.Equal("João", aplicacao.Cliente.Nome);
				Assert.Equal("CDB", aplicacao.ProdutoFinanceiro.Nome);

				contexto.Database.EnsureDeleted();
			}
		}

		[Fact]
		public void BuscaPorClienteProdutoFinanceiro_Aplicacao()
		{
			var opcoes = new DbContextOptionsBuilder<ContextoInvestimento>()
				.UseInMemoryDatabase(databaseName: "BuscaPorClienteProdutoFinanceiro_Aplicacao")
				.Options;

			using (var contexto = new ContextoInvestimento(opcoes))
			{
				var servicoProduto = new ServicoProdutoFinanceiro(contexto);
				servicoProduto.Adicionar("CDB");
				servicoProduto.Adicionar("Poupança");

				var servicoCliente = new ServicoCliente(contexto);
				servicoCliente.Adicionar("João");
				servicoCliente.Adicionar("Maria");

				var servicoAplicacao = new ServicoAplicacao(contexto);
				servicoAplicacao
					.Adicionar(2500.87m, servicoCliente.BuscaPorNome("João"), servicoProduto.BuscaPorNome("CDB"));
				servicoAplicacao
					.Adicionar(3666.43m, servicoCliente.BuscaPorNome("Maria"), servicoProduto.BuscaPorNome("Poupança"));

			}

			using (var contexto = new ContextoInvestimento(opcoes))
			{
				var servicoAplicacao = new ServicoAplicacao(contexto);
				var servicoProduto = new ServicoProdutoFinanceiro(contexto);
				var servicoCliente = new ServicoCliente(contexto);

				Cliente cliente = servicoCliente.BuscaPorNome("João");
				ProdutoFinanceiro produto = servicoProduto.BuscaPorNome("CDB");

				Aplicacao aplicacao = servicoAplicacao.BuscaPorClienteProdutoFinanceiro(cliente, produto);

				Assert.Equal(2500.87m, aplicacao.Valor);
				Assert.Equal("João", aplicacao.Cliente.Nome);
				Assert.Equal("CDB", aplicacao.ProdutoFinanceiro.Nome);

				contexto.Database.EnsureDeleted();
			}
		}
	}
}
