using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Data
{
    public class AliquotaContext : DbContext
    {
        public DbSet<ProdutoFinanceiro> ProdutosFinanceiros { get; set; }

        public DbSet<Aplicacao> Aplicacoes { get; set; }

        public AliquotaContext(DbContextOptions<AliquotaContext> dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
