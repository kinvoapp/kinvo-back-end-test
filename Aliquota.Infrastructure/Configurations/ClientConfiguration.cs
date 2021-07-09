using Aliquota.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aliquota.Infrastructure.Configurations
{
    public class ClientConfiguration: IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
                .ToTable("client");

            builder
                .Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            builder
                .Property(e => e.FantasyName)
                .HasColumnName("fantasy_name");

        }

    }
}