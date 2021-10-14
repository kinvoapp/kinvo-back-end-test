using Aliquota.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Data.Context
{
    public class AliquotaContext : DbContext
    {
        public AliquotaContext(DbContextOptions<AliquotaContext> options) : base(options) { }


        //Entidades do modelo mapeadas para as respectivas tabelas.
        public DbSet<Carteira> Carteiras { get; set; }
        public DbSet<ComprovanteResgate> ComprovantesResgates { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ProdutoFinanceiro> ProdutosFinanceiros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carteira>().HasOne(c => c.Cliente);
            modelBuilder.Entity<Carteira>().HasMany(c => c.ListaComprovanteResgate).WithOne(e => e.Carteira);
            modelBuilder.Entity<Carteira>().HasMany(c => c.ProdutoFinanceiro);
        }
    }
}
