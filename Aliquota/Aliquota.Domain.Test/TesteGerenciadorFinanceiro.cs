using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Aliquota.Domain.Test
{
	public class TesteGerenciadorFinanceiro
	{
		[Fact]
		public void Resgatar_GerenciadorFinanceiro()
		{
			var opcoes = new DbContextOptionsBuilder<ContextoInvestimento>()
				.UseInMemoryDatabase(databaseName: "Resgatar_GerenciadorFinanceiro")
				.Options;

			using (var contexto = new ContextoInvestimento(opcoes))
			{
				var servicoProduto = new ServicoProdutoFinanceiro(contexto);
				servicoProduto.Adicionar("CDB");
				servicoProduto.Adicionar("Poupança");
				servicoProduto.Adicionar("TesouroDireto");

				var servicoCliente = new ServicoCliente(contexto);
				servicoCliente.Adicionar("João");
				servicoCliente.Adicionar("Maria");
				servicoCliente.Adicionar("José");

				var servicoAplicacao = new ServicoAplicacao(contexto);
				servicoAplicacao
					.Adicionar(2500m, servicoCliente.BuscaPorNome("João"), servicoProduto.BuscaPorNome("CDB"));

				servicoAplicacao
					.Adicionar(2500m, servicoCliente.BuscaPorNome("Maria"), servicoProduto.BuscaPorNome("Poupança"));

				servicoAplicacao
					.Adicionar(2500m, servicoCliente.BuscaPorNome("José"), servicoProduto.BuscaPorNome("TesouroDireto"));

			}

			using (var contexto = new ContextoInvestimento(opcoes))
			{
				var servicoCliente = new ServicoCliente(contexto);
				var servicoProduto = new ServicoProdutoFinanceiro(contexto);
				var servicoAplicacao = new ServicoAplicacao(contexto);

				Cliente clienteJoao = servicoCliente.BuscaPorNome("João");
				ProdutoFinanceiro produtoCDB = servicoProduto.BuscaPorNome("CDB");

				Cliente clienteMaria = servicoCliente.BuscaPorNome("Maria");
				ProdutoFinanceiro produtoPoup = servicoProduto.BuscaPorNome("Poupança");

				Cliente clienteJose = servicoCliente.BuscaPorNome("José");
				ProdutoFinanceiro produtoTesouro = servicoProduto.BuscaPorNome("TesouroDireto");

				Aplicacao aplicacaoJoao = servicoAplicacao.BuscaPorClienteProdutoFinanceiro(clienteJoao, produtoCDB);
				Aplicacao aplicacaoMaria = servicoAplicacao.BuscaPorClienteProdutoFinanceiro(clienteMaria, produtoPoup);
				Aplicacao aplicacaoJose = servicoAplicacao.BuscaPorClienteProdutoFinanceiro(clienteJose, produtoTesouro);

				GerenciadorFinanceiro gerenciadorFinanceiro = 
					new GerenciadorFinanceiro(servicoCliente, servicoProduto, servicoAplicacao);

				// Cliente João, ProdutoFinanceiro CDB
				Dictionary<string, decimal> resultado = gerenciadorFinanceiro.Resgatar(clienteJoao, produtoCDB, aplicacaoJoao.DataInicial.AddDays(365), 12m);

				// 12% a.a -> 1,12 a.ano -> 1,0003105377556553767443007867263 a.dia
				// valorBruto = 2500 * 1,0003105377556553767443007867263 ^ 365 dias = 2800 
				// lucro = 300
				// imposto = 300 * 0,225 = 67,5
				// valorLiquido = 2800 - 67,5 = 2.732,5

				Assert.Equal(2800.00m, Math.Round(resultado["valorBruto"], 2));
				Assert.Equal(67.50m, Math.Round(resultado["imposto"], 2));
				Assert.Equal(2732.50m, Math.Round(resultado["valorLiquido"], 2));
				Assert.Equal(2, contexto.Aplicacoes.Count());

				// Cliente Maria, ProdutoFinanceiro Poupança
				Dictionary<string, decimal> resultadoMaria = gerenciadorFinanceiro.Resgatar(clienteMaria, produtoPoup, aplicacaoMaria.DataInicial.AddDays(500), 12m);

				// 12% a.a -> 1,12 a.ano -> 1,0003105377556553767443007867263 a.dia (365 dias)
				// valorBruto = 2500 * 1,0003105377556553767443007867263 ^ 500 dias = 2919,859522141612463743368052173 
				// lucro = 419,85952214161246374336805217297‬
				// imposto = lucro * 0,185 = 77,674011596198305792523089651999‬
				// valorLiquido = 2919,859522141612463743368052173 - 77,674011596198305792523089651999 = 2.842,185510545414157950844962521
				
				Assert.Equal(2919.86m, Math.Round(resultadoMaria["valorBruto"], 2));
				Assert.Equal(77.67m, Math.Round(resultadoMaria["imposto"], 2));
				Assert.Equal(2842.19m, Math.Round(resultadoMaria["valorLiquido"], 2));
				Assert.Equal(1, contexto.Aplicacoes.Count());

				// Cliente José, ProdutoFinanceiro Tesouro Direto
				Dictionary<string, decimal> resultadoJose = gerenciadorFinanceiro.Resgatar(clienteJose, produtoTesouro, aplicacaoJose.DataInicial.AddDays(800), 12m);

				// 12% a.a -> 1,12 a.ano -> 1,0003105377556553767443007867263 a.dia
				// valorBruto = 2500 * 1,0003105377556553767443007867263 ^ 800 dias = 3.204,904750515865147992845356895 
				// lucro = 704,90475051586514799284535689503
				// imposto = 704,90475051586514799284535689503 * 0,15 = 105,73571257737977219892680353425
				// valorLiquido = 3.204,904750515865147992845356895 - 105,73571257737977219892680353425 = 3.099,1690379384853757939185533607

				Assert.Equal(3204.90m, Math.Round(resultadoJose["valorBruto"], 2));
				Assert.Equal(105.74m, Math.Round(resultadoJose["imposto"], 2));
				Assert.Equal(3099.17m, Math.Round(resultadoJose["valorLiquido"], 2));
				Assert.Equal(0, contexto.Aplicacoes.Count());

				contexto.Database.EnsureDeleted();

			}
		}

		[Fact]
		public void Investir_GerenciadorFinanceiro()
		{
			var opcoes = new DbContextOptionsBuilder<ContextoInvestimento>()
				.UseInMemoryDatabase(databaseName: "Investir_GerenciadorFinanceiro")
				.Options;

			using (var contexto = new ContextoInvestimento(opcoes))
			{
				var servicoProduto = new ServicoProdutoFinanceiro(contexto);
				servicoProduto.Adicionar("CDB");

				var servicoCliente = new ServicoCliente(contexto);
				servicoCliente.Adicionar("João");

				var servicoAplicacao = new ServicoAplicacao(contexto);

				Cliente cliente = servicoCliente.BuscaPorNome("João");
				ProdutoFinanceiro produto = servicoProduto.BuscaPorNome("CDB");

				GerenciadorFinanceiro gerenciadorFinanceiro =
					new GerenciadorFinanceiro(servicoCliente, servicoProduto, servicoAplicacao);

				gerenciadorFinanceiro.Investir(cliente, produto, 2500.87m);

				gerenciadorFinanceiro.Investir(cliente, produto, 1499.13m);

			}

			using (var contexto = new ContextoInvestimento(opcoes))
			{
				Assert.Equal(1, contexto.Aplicacoes.Count());
				Assert.Equal(4000.00m, contexto.Aplicacoes.Single().Valor);

				contexto.Database.EnsureDeleted();

			}
		}
	}
}
