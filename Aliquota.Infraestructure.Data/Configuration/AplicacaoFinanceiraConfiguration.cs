using Aliquota.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aliquota.Infrastructure.Configuration
{
    public class AplicacaoFinanceiraConfiguration : IEntityTypeConfiguration<AplicacaoFinanceira>
    {
        public void Configure(EntityTypeBuilder<AplicacaoFinanceira> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(p => p.Valor)
                .IsRequired();
            builder.Property(p => p.DataAplicacao).IsRequired();
            builder.Property(p => p.DataRetirada);
            builder.HasOne(p => p.Cliente).WithMany(c => c.Aplicacoes);
            builder.HasOne(p => p.Produto);
        }
    }
}