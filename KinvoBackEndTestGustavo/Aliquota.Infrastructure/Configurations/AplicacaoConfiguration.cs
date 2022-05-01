using Aliquota.Domain.AplicacaoModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Aliquota.Infrastructure.Configurations
{
    public class AplicacaoConfiguration : IEntityTypeConfiguration<Aplicacao>
    {
        public void Configure(EntityTypeBuilder<Aplicacao> builder)
        {
            builder.ToTable("TB_APLICACAO");

            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Produto).WithMany(p => p.Aplicacoes).IsRequired();
            builder.Property(p => p.Valor).HasColumnType("DECIMAL(10,2)").IsRequired();
            builder.Property(p => p.DataAplicacao).HasColumnType("DATETIME").IsRequired();
            builder.Property(p => p.DataResgate).HasColumnType("DATETIME");
            builder.Property(p => p.Lucro).HasColumnType("DECIMAL(10,2");
        }
    }
}