using Aliquota.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Persistence.Context {
    public class AppDbContext : DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
    }
}