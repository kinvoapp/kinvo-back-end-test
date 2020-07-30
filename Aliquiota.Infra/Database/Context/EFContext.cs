using Aliquota.Domain;
using Microsoft.EntityFrameworkCore;

namespace Aliquiota.Infra.Database.Context
{
    public class EFContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aplicacao> Aplicacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:/Temp/aliquota.db");
        }
    }
}
