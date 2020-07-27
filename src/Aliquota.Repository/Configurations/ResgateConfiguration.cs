using Aliquota.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Repository.Configurations
{
    public class ResgateConfiguration : IEntityTypeConfiguration<Resgate>
    {
        public void Configure(EntityTypeBuilder<Resgate> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Data).IsRequired();

            builder.Property(x => x.ValorBruto).IsRequired();

            builder.Property(x => x.ValorLiquido).IsRequired();

            builder.Property(x => x.ImpostoRendaRecolhido).IsRequired();
        }
    }
}
