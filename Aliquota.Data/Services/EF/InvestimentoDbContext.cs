using System;
using Aliquota.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Data.Services.EF
{
    public class InvestimentoDbContext : DbContext
    {
        public InvestimentoDbContext(DbContextOptions<InvestimentoDbContext> options) : base(options)
        {
        }
        public InvestimentoDbContext()
        {
                
        }

        
        public DbSet<Carteira> Carteira { get; set; }
        public DbSet<Investimento> Investimento { get; set; }
        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure default schema
            //Map entity to table
            modelBuilder.Entity<Carteira>().HasKey(carteira => carteira.Id);
            modelBuilder.Entity<Investimento>().HasKey(investimento => investimento.Id);
            modelBuilder.Entity<Produto>().HasKey(produto => produto.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
