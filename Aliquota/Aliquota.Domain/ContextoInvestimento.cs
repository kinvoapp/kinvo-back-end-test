using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
	public class ContextoInvestimento : DbContext
	{
		public ContextoInvestimento()
		{	}

		public ContextoInvestimento(DbContextOptions<ContextoInvestimento> options)
			: base(options)
		{	}

		public DbSet<Cliente> Clientes { get; set; }

		public DbSet<ProdutoFinanceiro> ProdutosFinanceiros { get; set; }

		public DbSet<Aplicacao> Aplicacoes { get; set; }
	}
}
