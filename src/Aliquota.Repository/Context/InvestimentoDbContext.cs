using Aliquota.Repository.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Repository.Context
{
    public class InvestimentoDbContext: DbContext
    {
        public InvestimentoDbContext(DbContextOptions<InvestimentoDbContext> options) : base(options) => Database.EnsureCreated();
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AplicacaoConfiguration());
            modelBuilder.ApplyConfiguration(new ResgateConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
