using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliquota.Domain
{
	public class ServicoProdutoFinanceiro
	{
		private ContextoInvestimento _contexto;

		public ServicoProdutoFinanceiro(ContextoInvestimento contexto)
		{
			_contexto = contexto;
		}

		public void Adicionar(string nome)
		{
			var produto = new ProdutoFinanceiro { Nome = nome };
			_contexto.ProdutosFinanceiros.Add(produto);
			_contexto.SaveChanges();
		}

		public ProdutoFinanceiro BuscaPorNome(string nome)
		{
			var produto = _contexto.ProdutosFinanceiros.FirstOrDefault(p => p.Nome == nome);

			if (produto == null)
				throw new Exception("Produto não encontrado");

			return produto;
		}
	}
}
