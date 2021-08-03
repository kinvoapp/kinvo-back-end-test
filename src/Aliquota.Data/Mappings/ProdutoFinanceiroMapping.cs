using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aliquota.Data.Mappings
{
    public class ProdutoFinanceiroMapping : IEntityTypeConfiguration<ProdutoFinanceiro>
    {
        public void Configure(EntityTypeBuilder<ProdutoFinanceiro> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Aplicacao);

            builder.Property(c => c.DataAplicacao);

            builder.Property(c => c.Lucro);

            builder.Property(c => c.DataResgate);

            builder.ToTable("ProdutosFinanceiros");
        }
    }
}