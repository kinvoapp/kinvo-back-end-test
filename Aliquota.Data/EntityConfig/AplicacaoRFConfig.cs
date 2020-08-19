using Microsoft.EntityFrameworkCore;
using Aliquota.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aliquota.Data.EntityConfig
{
    public class AplicacaoRFConfig : IEntityTypeConfiguration<AplicacaoRF>
    {
        public void Configure(EntityTypeBuilder<AplicacaoRF> pBuilder)
        {
            pBuilder.HasKey(a => a.Id);

            pBuilder.Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(40);

            pBuilder.Property(a => a.DataAplicacao)
                .IsRequired();

            pBuilder.Property(a => a.DataResgate)
                .IsRequired();

            pBuilder.Property(a => a.ValorAplicado)
                .IsRequired();

            pBuilder.Property(a => a.TaxaJurosAnual)
                .IsRequired();

            pBuilder.Ignore(p => p.AliquotaIR);
            pBuilder.Ignore(p => p.RendimentoTotal);
            pBuilder.Ignore(p => p.IRRecolhido);
        }
    }
}