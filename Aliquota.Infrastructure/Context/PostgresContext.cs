    using Microsoft.EntityFrameworkCore;


using Aliquota.Domain.Entities;
using Aliquota.Infrastructure.Configurations;

namespace Aliquota.Infrastructure.Context
{
    public class PostgresContext : DbContext
    {
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Client> Clients { get; set; }

        public PostgresContext(DbContextOptions<PostgresContext> options ) : base(options){ }
        public PostgresContext(){ }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationConfiguration());
            
        }
    }
}