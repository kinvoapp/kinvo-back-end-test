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
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> clients)
        {
            clients
                .ToTable("Client");

            clients
                .HasKey(c => c.ClientId);

            clients
                .Property(c => c.ClientId)
                .HasColumnName("clientId")
                .HasColumnType("int")
                .IsRequired();

            clients
                .Property(c => c.Name)
                .HasColumnName("clientName")
                .HasColumnType("varchar(100)")
                .IsRequired();

            clients
                .Property(c => c.Cpf)
                .HasColumnName("cpf")
                .HasColumnType("varchar(11)")
                .IsRequired();
        }
    }
}
