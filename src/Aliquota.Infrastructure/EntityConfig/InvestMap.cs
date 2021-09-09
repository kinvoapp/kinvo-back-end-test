using Aliquota.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Infrastructure.EntityConfig
{
    public class InvestMap : IEntityTypeConfiguration<Invest>
    {
        public void Configure(EntityTypeBuilder<Invest> inv)
        {
            inv
                .ToTable("Investiment");

            inv
                .HasKey(i => i.InvestId);

            inv
                .Property(i => i.InvestId)
                .HasColumnType("int");

            inv
                .Property(i => i.InvestedValue)
                .HasColumnName("investMoney")
                .HasColumnType("money");

            inv
                .Property(i => i.AppDate)
                .HasColumnName("appDate")
                .HasColumnType("datetime")
                .IsRequired();

        }
    }
}
