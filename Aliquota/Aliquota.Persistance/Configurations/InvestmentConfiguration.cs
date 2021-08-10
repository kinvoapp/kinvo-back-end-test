using System;
using Aliquota.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aliquota.Persistance.Configurations
{
    public class InvestmentConfiguration : IEntityTypeConfiguration<Investment>
    {
        public void Configure(EntityTypeBuilder<Investment> builder)
        {
            builder.Property(inv => inv.Id)
                .IsRequired()
                .HasColumnType("decimal")
                .ValueGeneratedOnAdd();

            builder.Property(inv => inv.Amount)
                .HasColumnType("decimal(18,4)")
                .IsRequired();

            builder.Property(inv => inv.Start)
                .IsRequired();

            builder.Property(inv => inv.FinancialProductId)
                .HasColumnType("decimal")
                .IsRequired();

            builder.HasData(
                new Investment(1000, new DateTime(2019, 1, 1), 1) { Id = 1 },
                new Investment(5000, new DateTime(2012, 1, 1), 2) { Id = 2 },
                new Investment(10000, new DateTime(2020, 1, 1), 3) { Id = 3 },
                new Investment(9500, new DateTime(2018, 1, 1), 4) { Id = 4 },
                new Investment(2500, new DateTime(2015, 1, 1), 1) { Id = 5 },
                new Investment(3000, new DateTime(2009, 1, 1), 2) { Id = 6 },
                new Investment(7500, new DateTime(2010, 1, 1), 4) { Id = 7 }
            );
        }
    }
}
