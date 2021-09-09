using Aliquota.Domain.Models;
using Aliquota.Domain.ModelsConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain
{
    public class AliquotaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Investimento> Investimentos { get; set; }

        public AliquotaContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new InvestimentoConfiguration());
        }
    }
}
