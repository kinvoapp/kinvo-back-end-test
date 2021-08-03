using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Data
{
    public class AliquotaContext : DbContext
    {
        public AliquotaContext(DbContextOptions<AliquotaContext> options) : base(options)
        {
        }

        public DbSet<ProdutoFinanceiro> ProdutosFinanceiros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AliquotaContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}