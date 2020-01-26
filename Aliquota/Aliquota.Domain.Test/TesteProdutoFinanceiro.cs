using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Aliquota.Domain.Test
{
	public class TesteProdutoFinanceiro
	{
		[Fact]
		public void Adiciona_ProdutoFinanceiro()
		{
			var opcoes = new DbContextOptionsBuilder<ContextoInvestimento>()
				.UseInMemoryDatabase(databaseName: "Adiciona_ProdutoFinanceiro")
				.Options;

			using (var contexto = new ContextoInvestimento(opcoes))
			{
				var servico = new ServicoProdutoFinanceiro(contexto);
				servico.Adicionar("CDB");

			}

			using (var contexto = new ContextoInvestimento(opcoes))
			{
				Assert.Equal(1, contexto.ProdutosFinanceiros.Count());
				Assert.Equal("CDB", contexto.ProdutosFinanceiros.Single().Nome);
				Assert.Equal(1, contexto.ProdutosFinanceiros.Single().Id);

				contexto.Database.EnsureDeleted();
			}
		}

		[Fact]
		public void BuscaPorNome_ProdutoFinanceiro()
		{
			var opcoes = new DbContextOptionsBuilder<ContextoInvestimento>()
				.UseInMemoryDatabase(databaseName: "BuscaPorNome_ProdutoFinanceiro")
				.Options;

			using (var contexto = new ContextoInvestimento(opcoes))
			{
				var servico = new ServicoProdutoFinanceiro(contexto);
				servico.Adicionar("CDB");

			}

			using (var contexto = new ContextoInvestimento(opcoes))
			{
				var servico = new ServicoProdutoFinanceiro(contexto);
				ProdutoFinanceiro produto = servico.BuscaPorNome("CDB");

				Assert.Equal("CDB", produto.Nome);
				Assert.Equal(1, produto.Id);

				contexto.Database.EnsureDeleted();
			}
		}
	}
}

