using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContext) : base(dbContext) { }

        public DbSet<CadastroInvestidor> CadastroInvestidors { get; set; }
        public DbSet<TipoAplicacao> TipoAplicacaos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CadastroInvestidor>();
            modelBuilder.Entity<TipoAplicacao>();
        }
    }
}
