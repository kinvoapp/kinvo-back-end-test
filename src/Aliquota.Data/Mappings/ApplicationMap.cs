using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Aliquota.Infra.Data.Mappings
{
    public class ApplicationMap : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.ToTable("application");

            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.InitialValue)
                .HasColumnName("initial_value")
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(c => c.CurrentValue)
                .HasColumnName("current_value")
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(c => c.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(c => c.WithdrawnAt)
                .HasColumnName("withdrawn_at")
                .HasColumnType("datetime2");

            builder.Property(c => c.Active)
                .HasColumnName("active");

            builder.HasData(
                new Application
                {
                    Name = "Sample application",
                    InitialValue = 100.00m,
                    CurrentValue = 300.00m,
                    CreatedAt = new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                },
                new Application
                {
                    Name = "Second application",
                    InitialValue = 100.00m,
                    CurrentValue = 300.00m,
                    CreatedAt = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                },
                new Application
                {
                    Name = "Third application",
                    InitialValue = 100.00m,
                    CurrentValue = 300.00m,
                    CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}
