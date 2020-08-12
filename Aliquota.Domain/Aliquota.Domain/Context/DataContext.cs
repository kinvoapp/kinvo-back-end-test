using Aliquota.Domain.Models;
using Aliquota.Domain.Models.BD;
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

        public DbSet<BDCadastroInvestidor> BDCadastroInvestidors { get; set; }
        public DbSet<BDResultadoFinanceiro> BDResultadoFinanceiros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BDCadastroInvestidor>();
            modelBuilder.Entity<BDResultadoFinanceiro>();
        }
    }
}
