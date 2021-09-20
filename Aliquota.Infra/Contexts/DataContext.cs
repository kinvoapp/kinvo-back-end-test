using Aliquota.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Client> Client { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Product>().ToTable("Products");
        //     modelBuilder.Entity<Product>().Property(x => x.Id);
        //     modelBuilder.Entity<Product>().Property(x => x.Title).HasMaxLength(120).HasColumnType("varchar(120)");
        //     modelBuilder.Entity<Product>().Property(x => x.ApplicationDate);
        //     modelBuilder.Entity<Product>().Property(x => x.EndApplicationDate);
        //     modelBuilder.Entity<Product>().Property(x => x.Price);

        //     modelBuilder.Entity<Client>().ToTable("Clients");
        //     modelBuilder.Entity<Client>().Property(x => x.Id);
        //     modelBuilder.Entity<Client>().Property(x => x.Name).HasMaxLength(120).HasColumnType("varchar(120)");
        // }
    }
}
