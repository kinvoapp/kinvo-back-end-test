using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.AppConSql.Contexto
{
   class Context : DbContext {

      public DbSet<Cliente> Clientes { get; set; }
      public DbSet<Aplicacao> Aplicacoes { get; set; }
      public DbSet<Rendimento> Rendimentos { get; set; }
      public DbSet<Resgate> Resgates { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder.UseSqlServer("Data Source=DESKTOP-MKHD0E4\\SQLSERVERDEV;Initial Catalog=KinvoDB; User ID=paulo; Password=lopes; ApplicationIntent=ReadWrite; MultipleActiveResultSets=true");
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Rendimento>()
             .HasIndex(r => r.Data)
             .IsUnique();
      }


   }
}
