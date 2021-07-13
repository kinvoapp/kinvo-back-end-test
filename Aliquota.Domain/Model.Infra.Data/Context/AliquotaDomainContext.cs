using Microsoft.EntityFrameworkCore;
using Model.Domain.Entities;
using Model.Infra.Data.Mapping;

namespace Model.Infra.Data.Context
{
    public class AliquotaDomainContext : DbContext
    {
        public AliquotaDomainContext(DbContextOptions<AliquotaDomainContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Investment> Investments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<Investment>(new InvestmentMap().Configure);
        }
    }
}
