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
		public void Adiciona_Aplicacao()
		{
			var opcoes = new DbContextOptionsBuilder<ContextoInvestimento>()
				.UseInMemoryDatabase(databaseName: "Aplicacao")
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
	}
}
