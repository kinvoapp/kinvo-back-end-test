using System.ComponentModel.DataAnnotations;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Queries;
using Flunt.Notifications;
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
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<CustomerQueryResult> CustomerQueryResult { get; set; }
        public DbSet<ProductsQueryResult> ProductsQueryResult { get; set; }
        public DbSet<OrdersQueryResult> OrdersQueryResult { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Notification>();
            //modelBuilder.Ignore<DomainEvent>();
        }
    }
}
