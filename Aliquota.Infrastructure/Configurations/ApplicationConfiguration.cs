using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Aliquota.Domain.Entities;

namespace Aliquota.Infrastructure.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder
                .ToTable("application");

            builder
                .Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            builder
                .Property(e => e.ApplicationDate)
                .HasColumnName("application_date");

            builder
                .Property(e => e.ApplicationValue)
                .HasColumnName("application_value");

            builder
                .Property(e => e.WithdrawDate)
                .HasColumnName("withdraw_date");

            builder
                .Property(e => e.WithdrawValue)
                .HasColumnName("withdraw_value");

            builder
                .HasOne(d => d.Client)
                .WithMany(p => p.ListApplications)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("client_id");

            builder
                .Property(e => e.ClientId)
                .HasColumnName("client_id");

            builder
                .Property(e => e.IsActive)
                .HasColumnName("is_active");
        }
    }
}