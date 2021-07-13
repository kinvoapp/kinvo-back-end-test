using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Infra.Data.Mapping
{
    public class InvestmentMap : IEntityTypeConfiguration<Investment>
    {
        public void Configure(EntityTypeBuilder<Investment> builder)
        {
            builder.ToTable("Investment");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Cpf)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Cpf")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Capital)
                .IsRequired()
                .HasColumnName("Capital")
                .HasColumnType("money");

            builder.Property(prop => prop.InvestmentDayZero)
                .IsRequired()
                .HasColumnName("Starting day")
                .HasColumnType("datetime");
        }
    }
}
