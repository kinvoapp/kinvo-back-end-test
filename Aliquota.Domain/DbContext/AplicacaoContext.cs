using Microsoft.EntityFrameworkCore;
namespace Aliquota.Domain.Models
{
    public class AplicacaoContext : DbContext
    {
        public DbSet<Aplicacao> Aplicacoes { get; set; }

        private string _connectionString =
            @"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0";

        public AplicacaoContext() { }
        public AplicacaoContext(DbContextOptions<AplicacaoContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseInMemoryDatabase(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
    }
