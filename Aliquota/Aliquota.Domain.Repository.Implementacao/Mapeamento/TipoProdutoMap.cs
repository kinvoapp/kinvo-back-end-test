using Aliquota.Domain.Entities.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Repository.Implementacao.Mapeamento
{
    public class TipoProdutoMap : IEntityTypeConfiguration<TipoProduto>
    {
        public void Configure(EntityTypeBuilder<TipoProduto> builder)
        {
            builder.ToTable("tb_tipoproduto");

            builder.HasKey(e => e.IdTipoProduto);

            builder.Ignore(e => e.Id);
            builder.Ignore(e => e.Descricao);

            builder.Property(e => e.IdTipoProduto).HasColumnName("id_tipoproduto").ValueGeneratedOnAdd();
            builder.Property(e => e.NomeTipoProduto).HasColumnName("nom_tipoproduto");
            builder.Property(e => e.Rentabilidade).HasColumnName("val_rentabilidade");
        }
    }
}
