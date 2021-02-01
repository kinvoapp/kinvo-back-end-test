using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aliquota.Data.Mappings
{
    public class AplicacaoMapping : IEntityTypeConfiguration<Aplicacao>
    {
        public void Configure(EntityTypeBuilder<Aplicacao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("Aplicacao");
        }
    }
}
