using Aliquota.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aliquota.Infra.Data.EntityConfig
{
    class AplicacaoFinanceiraConfiguration : IEntityTypeConfiguration<AplicacaoFinanceira>
    {
        public void Configure(EntityTypeBuilder<AplicacaoFinanceira> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(a => a.DataAplicacao)
                .IsRequired();

            builder.Property(a => a.DataResgate)
                .IsRequired();

            builder.Property(a => a.ValorAplicacao)
                .IsRequired();

            builder.Property(a => a.RentabilidadeAnual)
                .IsRequired();

        }

    }
}
