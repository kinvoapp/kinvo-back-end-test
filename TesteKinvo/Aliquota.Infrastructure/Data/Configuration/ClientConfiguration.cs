using Aliquota.Application.Dtos;
using Aliquota.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Infrastructure.Data.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<ClientDto>
    {
        public void Configure(EntityTypeBuilder<ClientDto> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
