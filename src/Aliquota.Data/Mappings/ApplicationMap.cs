using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.Property(c => c.Value)
                .HasColumnName("value")
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(c => c.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(c => c.WithdrawnAt)
                .HasColumnName("withdrawn_at")
                .HasColumnType("datetime2");
        }
    }
}
