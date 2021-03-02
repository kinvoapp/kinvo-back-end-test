using Aliquota.Domain.AggregatesModel.AplicacaoAggregate;
using Aliquota.Domain.AggregatesModel.ProdutoFinanceiroAggregate;
using Aliquota.Domain.AggregatesModel.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Aliquota.Infrastructure.EntityConfigurations
{
    class AplicacaoTypeConfiguration : IEntityTypeConfiguration<Aplicacao>
    {
        public void Configure(EntityTypeBuilder<Aplicacao> aplicacaoConfiguration)
        {
            aplicacaoConfiguration.HasKey(o => o.Id);

            aplicacaoConfiguration
                .Property<double>("valorInicial")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired();

            aplicacaoConfiguration
                .Property<double?>("valorResgate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired(false);

            aplicacaoConfiguration
                .Property<DateTime>("dataInicial")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired();

            aplicacaoConfiguration
                .Property<DateTime?>("dataResgate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired();

            aplicacaoConfiguration
                .Property<int?>("usuarioId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired(true);

            aplicacaoConfiguration
                .Property<int?>("produtoFinanceiroId")
                .IsRequired(true)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            aplicacaoConfiguration.HasOne<ProdutoFinanceiro>()
                .WithMany()
                .HasForeignKey("produtoFinanceiroId")
                .IsRequired(true);

            aplicacaoConfiguration.HasOne<Usuario>()
                .WithMany()
                .HasForeignKey("usuarioId")
                .IsRequired(true);
        }
    }
}
