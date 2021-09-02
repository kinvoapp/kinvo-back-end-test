using Aliquota.Domain.Entities.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Repository.Implementacao.Mapeamento
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("tb_cliente");

            builder.HasKey(e => e.Id);
            builder.Ignore(e => e.Descricao);

            builder.Property(e => e.Id).HasColumnName("id_cliente").ValueGeneratedOnAdd();
            builder.Property(e => e.NomeCliente).HasColumnName("nom_cliente");

        }
    }
}
