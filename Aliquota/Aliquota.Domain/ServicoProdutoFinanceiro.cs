using System;
using System.Collections.Generic;
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
	}
}
