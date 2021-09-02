using Aliquota.Domain.Entities.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Repository.Implementacao.Mapeamento
{
    public class SituacaoProdutoMap : IEntityTypeConfiguration<SituacaoProduto>
    {
        public void Configure(EntityTypeBuilder<SituacaoProduto> builder)
        {
            builder.ToTable("tb_situacaoproduto");

            builder.HasKey(e => e.Id);

            builder.Ignore(e => e.Descricao);

            builder.Property(e => e.Id).HasColumnName("id_situacaoproduto").ValueGeneratedOnAdd();
            builder.Property(e => e.Situacao).HasColumnName("nom_situacao");
        }
    }
}
