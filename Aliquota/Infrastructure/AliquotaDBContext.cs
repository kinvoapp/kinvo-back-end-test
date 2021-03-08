using Aliquota.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Aliquota.Infrastructure.DBContext
{
    public class AliquotaDBContext : DbContext
    {
        public AliquotaDBContext(DbContextOptions<AliquotaDBContext> a_options) : base(a_options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                    .AddJsonFile("settings.json")
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Aplicacao> Aplicacao { get; set; }
        public DbSet<ProdutoFinanceiro> ProdutoFinanceiro { get; set; }        
    }
}
