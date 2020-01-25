using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
	public class Aplicacao
	{
		public int Id { get; set; }
		public decimal Valor { get; set; }
		public DateTime DataInicial { get; set; }
		public int IdCliente { get; set; }
		public Cliente Cliente { get; set; }
		public int IdProdutoFinanceiro { get; set; }
		public ProdutoFinanceiro ProdutoFinanceiro { get; set; }


	}
}
