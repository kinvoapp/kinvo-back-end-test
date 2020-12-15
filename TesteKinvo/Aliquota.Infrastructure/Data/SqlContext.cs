using Aliquota.Domain.Entitys;
using Aliquota.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Infrastructure.Data
{
   public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<FinancialApplication> Applications { get; set; }

       /* private void SetModelConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new FinancialApplicationConfiguration());
        }/*

     /*   public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(
            {

            }
            return base.SaveChanges();
        }*/
    }
}
