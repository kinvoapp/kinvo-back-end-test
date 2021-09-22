using System.ComponentModel.DataAnnotations;
using Aliquota.Domain.Entities;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ignorando validações e notificações do ef
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Notification>();
        }
    }
}
