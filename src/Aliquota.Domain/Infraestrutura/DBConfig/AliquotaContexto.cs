using Aliquota.Domain.Infraestrutura.DBConfig.EntityConfig;
using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.Infraestrutura.DBConfig
{
    public class AliquotaContexto:DbContext
    {
        public DbSet<ProdutoFinanceiro> ProdutosFinanceiros { get; set; }
        public DbSet<TipoProdutoFinanceiro> TiposProdutosFinanceiros { get; set; }

        public AliquotaContexto(DbContextOptions<AliquotaContexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProdutoFinanceiroEC());
            builder.ApplyConfiguration(new TipoProdutoFinanceiroEC());
        }

    }
}
