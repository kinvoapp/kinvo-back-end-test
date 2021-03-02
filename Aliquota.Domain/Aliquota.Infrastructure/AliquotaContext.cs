using Aliquota.Domain.AggregatesModel.AplicacaoAggregate;
using Aliquota.Domain.AggregatesModel.ProdutoFinanceiroAggregate;
using Aliquota.Domain.AggregatesModel.Usuario;
using Aliquota.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

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
