
using Microsoft.EntityFrameworkCore;
using src.Database.Mappings;
using src.Models;

namespace src.Database
{
    public class KinvoDbContext : DbContext
    {
        public KinvoDbContext() { }

        public KinvoDbContext(DbContextOptions<KinvoDbContext> options) : base(options) { }

        public virtual DbSet<AplicacaoFundo> AplicacaoFundo { get; set; }
        public virtual DbSet<ResgateFundo> ResgateFundo { get; set; }
        public virtual DbSet<SaldoFundo> SaldoFundo { get; set; }
        public virtual DbSet<FundoInvestimento> FundoInvestimento { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AplicacaoFundoMap());
            modelBuilder.ApplyConfiguration(new ResgateFundoMap());
            modelBuilder.ApplyConfiguration(new SaldoFundoMap());
            modelBuilder.ApplyConfiguration(new FundoInvestimentoMap());
        }

    }
}
