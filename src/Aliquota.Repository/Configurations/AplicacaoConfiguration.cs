using Aliquota.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Repository.Configurations
{
    public class AplicacaoConfiguration : IEntityTypeConfiguration<Aplicacao>
    {
        public void Configure(EntityTypeBuilder<Aplicacao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Valor).IsRequired();

            builder.Property(x => x.ValorCorrigido).IsRequired();

            builder.Property(x => x.PercentualRendimentoMes).IsRequired();

            builder.Property(x => x.Data).IsRequired();

            builder.Property(x => x.TaxaImpostoRenda).IsRequired();

            builder.HasOne(x => x.Resgate).WithOne(x => x.Aplicacao).HasForeignKey<Resgate>(x => x.AplicacaoId);
        }
    }
}
