using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Aliquota.Application.Interfaces;
using Aliquota.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FinancialProduct> FinancialProducts { get; set; }
        public DbSet<Investment> Investments { get; set; }
        public DbSet<Withdraw> Withdraws { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}