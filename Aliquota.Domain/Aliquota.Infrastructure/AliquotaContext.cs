using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Aliquota.Domain.AggregatesModel.ProdutoFinanceiroAggregate;
using Aliquota.Domain.AggregatesModel.Usuario;
using Aliquota.Infrastructure.EntityConfigurations;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Aliquota.Domain.SeedWork;
using System.Threading;
using Aliquota.Domain.AggregatesModel.AplicacaoAggregate;

namespace Aliquota.Infrastructure
{
    public class AliquotaContext : DbContext
    {
        public AliquotaContext(DbContextOptions<AliquotaContext> options) : base(options)
        { }

        public DbSet<ProdutoFinanceiro> produtoFinanceiros { get; set; }
        public DbSet<Aplicacao> aplicacoes { get; set; }
        public DbSet<Usuario> usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoFinanceiroTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AplicacaoTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioTypeConfiguration());
        }
    }
}
