using Aliquota.Data.Entity;
using Microsoft.EntityFrameworkCore;


namespace Aliquota.Data.Context
{
    public class AliquotaContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<Client> Clients { get; set; }
        
        public AliquotaContext(DbContextOptions<AliquotaContext> options) : base(options) { }
    }
}