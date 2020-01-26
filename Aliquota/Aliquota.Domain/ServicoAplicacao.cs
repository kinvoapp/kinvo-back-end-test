using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliquota.Domain
{
	public class ServicoAplicacao
	{
		private ContextoInvestimento _contexto;

		public ServicoAplicacao(ContextoInvestimento contexto)
		{
			_contexto = contexto;
		}

		public void Remover(Aplicacao aplicacao)
		{
			if (!VerificaAplicacaoExiste(aplicacao))
				throw new ArgumentException("A aplicação não existe.");

			_contexto.Aplicacoes.Remove(aplicacao);
			_contexto.SaveChanges();
		}

		public Aplicacao BuscaPorClienteProdutoFinanceiro(Cliente cliente, ProdutoFinanceiro produto)
		{
			if (cliente == null)
				throw new ArgumentException("É necessário fornecer um cliente.");

			if (produto == null)
				throw new ArgumentException("É necessário fornecer um produto financeiro.");

			Aplicacao aplicacao = _contexto.Aplicacoes
				.Include(a => a.ProdutoFinanceiro)
				.Include(a => a.Cliente)
				.SingleOrDefault(a => a.Cliente.Id == cliente.Id && a.ProdutoFinanceiro.Id == produto.Id);

			return aplicacao;
		}

		public Aplicacao Atualizar(decimal valor, Cliente cliente, ProdutoFinanceiro produto)
		{
			this.ValidaArgumentosAplicacao(valor, cliente, produto);

			Aplicacao aplicacao;
			// verificar se ja existe aplicacao com mesmo Cliente e ProdutoFinanceiro
			if (!this.VerificaAplicacaoExiste(cliente, produto))
				throw new Exception("A aplicação não existe");

			aplicacao = _contexto.Aplicacoes.Single(a =>
				a.Cliente.Id == cliente.Id &&
				a.ProdutoFinanceiro.Id == produto.Id);

			aplicacao.Valor += valor;

			_contexto.SaveChanges();

			return aplicacao;
		}

		public Aplicacao Adicionar(decimal valor, Cliente cliente, ProdutoFinanceiro produto)
		{
			this.ValidaArgumentosAplicacao(valor, cliente, produto);

			Aplicacao aplicacao;

			if (this.VerificaAplicacaoExiste(cliente, produto))
				throw new Exception("A aplicação já existe");

			aplicacao = new Aplicacao
			{
				Valor = valor,
				DataInicial = DateTime.Now,
				IdCliente = cliente.Id,
				IdProdutoFinanceiro = produto.Id,
				// work around, .include not working
				Cliente = cliente,
				ProdutoFinanceiro = produto
			};
			_contexto.Add(aplicacao);

			_contexto.SaveChanges();

			return aplicacao;
		}

		private bool VerificaAplicacaoExiste(Cliente cliente, ProdutoFinanceiro produto)
		{
			bool aplicacaoExiste = _contexto.Aplicacoes.Any(a =>
				a.Cliente.Nome == cliente.Nome &&
				a.ProdutoFinanceiro.Nome == produto.Nome);

			return aplicacaoExiste;
		}

		private bool VerificaAplicacaoExiste(Aplicacao aplicacao)
		{
			bool aplicacaoExiste = _contexto.Aplicacoes.Any(a => a.Id == aplicacao.Id);

			return aplicacaoExiste;
		}

		private void ValidaArgumentosAplicacao(decimal valor, Cliente cliente, ProdutoFinanceiro produto)
		{
			if (valor <= 0)
				throw new ArgumentException("O valor da aplicação deve ser maior que 0");

			if (cliente == null)
				throw new ArgumentException("É necessário fornecer um cliente.");

			if (produto == null)
				throw new ArgumentException("É necessário fornecer um produto financeiro.");

			if (!_contexto.Clientes.Any(c => c.Id == cliente.Id))
				throw new ArgumentException("O cliente não existe");

			if (!_contexto.ProdutosFinanceiros.Any(p => p.Id == cliente.Id))
				throw new ArgumentException("O produto financeiro não existe");
		}
	}
}
