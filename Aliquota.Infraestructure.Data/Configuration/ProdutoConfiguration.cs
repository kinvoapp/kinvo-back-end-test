using Aliquota.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aliquota.Infrastructure.Configuration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<ProdutoFinanceiro>
    {
        public void Configure(EntityTypeBuilder<ProdutoFinanceiro> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(p => p.Descricao)
                .IsRequired();
            builder.Property(p => p.TaxaRedendimento).IsRequired();
        }
    }
}