using Aliquota.Domain.Entitys;
using Aliquota.Infrastructure.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Infrastructure.Context
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients{ get; set; }
        public DbSet<Invest> Invests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new InvestMap());


        }



    }

}
