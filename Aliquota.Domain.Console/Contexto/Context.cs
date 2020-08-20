using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.AppConsole.Contexto
{
   class Context : DbContext {

      public DbSet<Cliente> Clientes { get; set; }
      public DbSet<Aplicacao> Aplicacoes { get; set; }
      public DbSet<Rendimento> Rendimentos { get; set; }
      public DbSet<Resgate> Resgates { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder.UseSqlite("Data Source = kinvo.db;");
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Rendimento>()
             .HasIndex(r => r.Data)
             .IsUnique();
      }

   }
}
