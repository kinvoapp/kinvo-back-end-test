using Aliquota.Domain;
using Aliquota.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Data
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options) : base(options)
        {
        }

        public virtual DbSet<IR> IR { get; set; }
        public virtual DbSet<Aplicacao> Aplicacao { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:aliquota-domaindbserver.database.windows.net,1433;Initial Catalog=Aliquota.Domain_db;Persist Security Info=False;
                                        User ID=aliquota;Password=Henrique1299;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IR>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id").IsRequired();
                entity.Property(e => e.valor).HasColumnName("valor");
                entity.Property(e => e.dataResgate)
                .HasColumnName("dataResgate");
                entity.Property(e => e.dataAplicacao).HasColumnName("dataAplicacao");
                entity.Property(e => e.ir).HasColumnName("ir");
                entity.Property(e => e.lucro).HasColumnName("lucro");
                entity.Property(e => e.aliquota).HasColumnName("aliquota");
            });
            modelBuilder.Entity<Aplicacao>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id").IsRequired();
                entity.Property(e => e.valor).HasColumnName("valor");
                entity.Property(e => e.dataAplicacao).HasColumnName("dataAplicacao");
            });
        }
    }
}
