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

		public void Adicionar(decimal valor, Cliente cliente, ProdutoFinanceiro produto)
		{
			if (valor <= 0)
				throw new ArgumentException("O valor da aplicação deve ser maior que 0");

			if (!_contexto.Clientes.Any(c => c.Id == cliente.Id))
				throw new ArgumentException("O cliente não existe");

			if (!_contexto.ProdutosFinanceiros.Any(p => p.Id == cliente.Id))
				throw new ArgumentException("O produto financeiro não existe");

			Aplicacao aplicacao;
			// verificar se ja existe aplicacao com mesmo Cliente e ProdutoFinanceiro
			if (this.VerificaAplicacaoExiste(cliente, produto))
			{
				aplicacao = _contexto.Aplicacoes.Single(a =>
				a.Cliente.Id == cliente.Id &&
				a.ProdutoFinanceiro.Id == produto.Id);

				aplicacao.Valor += valor;
			}
			else 
			{
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

			}

			_contexto.SaveChanges();
		}

		private bool VerificaAplicacaoExiste(Cliente cliente, ProdutoFinanceiro produto)
		{
			bool aplicacaoExiste = _contexto.Aplicacoes.Any(a =>
				a.Cliente.Nome == cliente.Nome &&
				a.ProdutoFinanceiro.Nome == produto.Nome);

			return aplicacaoExiste;
		}
	}
}
