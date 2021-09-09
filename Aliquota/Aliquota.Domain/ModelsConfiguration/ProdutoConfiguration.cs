using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aliquota.Domain.ModelsConfiguration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder
                .ToTable("Produto");

            builder
                .Property(p => p.Nome)
                .HasColumnType("varchar")
                .IsRequired();

            builder
                .Property(p => p.TaxaRendimentoAnual)
                .HasColumnType("decimal(10,2)");
        }
    }
}
