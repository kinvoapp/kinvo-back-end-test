using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.Data
{
    public class AliquotaDbContext : DbContext
    {
        public AliquotaDbContext(DbContextOptions<AliquotaDbContext> options) : base(options)
        {
        }

        public DbSet<Investment> Investments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Investment>(p =>
            {
                p.HasKey(p => p.Id);
                p.Property(p => p.InvestmentDate).HasColumnType("DATE").IsRequired();
                p.Property(p => p.Value).HasColumnType("DECIMAL(18,2)").IsRequired();
                p.Property(p => p.RescueDate).HasColumnType("DATE");
            });
        }
    }
}
