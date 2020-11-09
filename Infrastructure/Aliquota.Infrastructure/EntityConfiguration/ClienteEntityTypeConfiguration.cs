using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Aliquota.Domain.Models;

namespace Aliquota.Infrastructure.EntityConfiguration
{
    internal class ClienteEntityTypeConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes", "dbo");

            builder.HasKey(r => r.Id);

            builder.Property(e => e.Nome).IsRequired();
            builder.Property(e => e.CPF).IsRequired();
        }
    }
}
