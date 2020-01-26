using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Aliquota.Domain.Test
{
	
	public class TesteCliente
	{
		[Fact]
		public void Adiciona_Cliente()
		{
			var opcoes = new DbContextOptionsBuilder<ContextoInvestimento>()
				.UseInMemoryDatabase(databaseName: "Adiciona_Cliente")
				.Options;

			using (var contexto = new ContextoInvestimento(opcoes))
			{
				var servico = new ServicoCliente(contexto);
				servico.Adicionar("João");
				
			}

			using (var contexto = new ContextoInvestimento(opcoes))
			{
				Assert.Equal(1, contexto.Clientes.Count());
				Assert.Equal("João", contexto.Clientes.Single().Nome);
				Assert.Equal(1, contexto.Clientes.Single().Id);

				contexto.Database.EnsureDeleted();
			}
		}

		[Fact]
		public void BuscaPorNome_Cliente()
		{
			var opcoes = new DbContextOptionsBuilder<ContextoInvestimento>()
				.UseInMemoryDatabase(databaseName: "BuscaPorNome_Cliente")
				.Options;

			using (var contexto = new ContextoInvestimento(opcoes))
			{
				var servico = new ServicoCliente(contexto);
				servico.Adicionar("João");

			}

			using (var contexto = new ContextoInvestimento(opcoes))
			{
				var servico = new ServicoCliente(contexto);
				Cliente cliente = servico.BuscaPorNome("João");

				Assert.Equal("João", cliente.Nome);
				Assert.Equal(1, cliente.Id);

				contexto.Database.EnsureDeleted();
			}
		}
	}
}

