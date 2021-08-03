using Aliquota.Domain.Entidades;
using Aliquota.Domain.Infra.Contextos.Base;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Infra.Contextos
{
    public class AliquotaContexto : ContextoBase
    {
        public override string NomeContexto => nameof(AliquotaContexto);
        public DbSet<ProdutoFinanceiro> ProdutoFinanceiros { get; set; }

        public AliquotaContexto(DbContextOptions<AliquotaContexto> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AliquotaContexto).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}