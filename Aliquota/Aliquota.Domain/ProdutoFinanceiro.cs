using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
	public class ProdutoFinanceiro
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public IEnumerable<Aplicacao> Aplicacoes { get; set; }
	}
}
