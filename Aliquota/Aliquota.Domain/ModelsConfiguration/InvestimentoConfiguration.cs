using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aliquota.Domain.ModelsConfiguration
{
    class InvestimentoConfiguration : IEntityTypeConfiguration<Investimento>
    {
        public void Configure(EntityTypeBuilder<Investimento> builder)
        {
            builder
                .Property(i => i.DataInvestimento)
                .HasColumnType("date")
                .IsRequired();

            builder
                .Property(i => i.DataResgate)
                .HasColumnType("date");

            builder
                .Property(i => i.ValorInvestido)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder
                .Property(i => i.ValorResgatado)
                .HasColumnType("decimal(10,2)");


            builder
                .Property(i => i.ImpostoRecolhido)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(i => i.ImpostoFaixaAplicavel)
                .HasColumnType("decimal(10,2)");
        }
    }
}
