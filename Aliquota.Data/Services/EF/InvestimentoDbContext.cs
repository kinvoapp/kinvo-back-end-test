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

        public DbSet<Carteira> Carteiras { get; set; }
        public DbSet<Investimento> Investimentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

    }
}
