using Aliquota.Domain.Models;
using Aliquota.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Infrastructure
{
    public class AliquotaDbContext : DbContext
    {
        // public AliquotaDbContext(DbContextOptions<AliquotaDbContext> options)
        //     : base(options)
        // {}

        private string connection = @"Server=localhost;Database=master;User=sa;Password=yourStrong(!)Password;";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(this.connection);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoFinanceiroEntityTypeConfiguration());
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ProdutoFinanceiro> ProdutosFinanceiros { get; set; }
    }
}
