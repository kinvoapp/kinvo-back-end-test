using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Aliquota.Domain.Models;

namespace Aliquota.Infrastructure.EntityConfiguration
{
    internal class ProdutoFinanceiroEntityTypeConfiguration : IEntityTypeConfiguration<ProdutoFinanceiro>
    {
        public void Configure(EntityTypeBuilder<ProdutoFinanceiro> builder)
        {
            builder.ToTable("ProdutosFinanceiros", "dbo");

            builder.HasKey(r => r.Id);
            builder.Property(e => e.Valor).IsRequired();
            builder.Property(e => e.DataAplicacao).IsRequired();
            builder.Property(e => e.DataResgate);
            builder.Property(e => e.AliquotaImposto);
            builder.HasOne(e => e.Cliente).WithMany(b => b.ProdutosFinanceiros);
        }
    }
}
