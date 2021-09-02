using AliquotaImpostoRenda.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AliquotaImpostoRenda.Data.Context
{
    public class AliquotaImpostoRendaContext : DbContext
    {
        public AliquotaImpostoRendaContext(){}

        public AliquotaImpostoRendaContext(DbContextOptions<AliquotaImpostoRendaContext> opcoes) : base(opcoes) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TesteAliquota");
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ExtratoAplicacao> ExtratoAplicacao { get; set; }
    }
}
