using Aliquota.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.Repository.Context
{
    public class AliquotContext : DbContext
    {
        public DbSet<Share> Shares { get; set; }

        public AliquotContext(DbContextOptions<AliquotContext> options) : base(options) {}
    }
}
