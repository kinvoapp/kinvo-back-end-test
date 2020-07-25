using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using Aliquota.Infrastructure.Configuration;
using Aliquota.Domain.Entity;

namespace Aliquota.Infrastructure.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ProdutoFinanceiro> Produto { get; set; }
        public DbSet<AplicacaoFinanceira> Aplicacao { get; set; }


        private void SetModelConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new AplicacaoFinanceiraConfiguration());
        }
    }
}