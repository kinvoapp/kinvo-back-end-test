using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aliquota.Domain.Infraestrutura.DBConfig.EntityConfig
{
    public class ProdutoFinanceiroEC : IEntityTypeConfiguration<ProdutoFinanceiro>
    {
        public void Configure(EntityTypeBuilder<ProdutoFinanceiro> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("newid()");
            builder.Property(p => p.ValorAplicado).IsRequired();
            builder.Property(p => p.ValorIR).HasDefaultValue(0).IsRequired();
            builder
                .Property(p => p.DataAplicacao)
                    .HasColumnType("date")
                        .HasDefaultValueSql("GETDATE()")
                            .IsRequired();
            builder.Property(p => p.DataResgate).HasColumnType("date");
            builder.Ignore(p => p.Lucro);
            builder
                .HasOne(p => p.TipoProdutoFinanceiro)
                    .WithMany()
                        .HasForeignKey(p => p.TipoProdutoFinanceiroFK);
            builder
                .Property(p => p.Status)
                    .HasDefaultValue(Status.EmAplicacao)
                        .HasConversion<int>();
        }
    }
}
