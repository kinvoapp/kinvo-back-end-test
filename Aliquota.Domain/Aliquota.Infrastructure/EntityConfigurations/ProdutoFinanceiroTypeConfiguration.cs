using Aliquota.Domain.AggregatesModel.ProdutoFinanceiroAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aliquota.Infrastructure.EntityConfigurations
{
    class ProdutoFinanceiroTypeConfiguration : IEntityTypeConfiguration<ProdutoFinanceiro>
    {
        public void Configure(EntityTypeBuilder<ProdutoFinanceiro> produtoFinanceiroConfiguration)
        {
            produtoFinanceiroConfiguration.HasKey(o => o.Id);

            produtoFinanceiroConfiguration
                .Property<double>("taxaDeRendimento")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired(true);

            produtoFinanceiroConfiguration
                .Property<string>("descricao")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired(true);
        }
    }
}
