using Aliquota.Domain.Entities.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Repository.Implementacao.Mapeamento
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("tb_produto");

            builder.HasKey(e => e.IdProduto);

            builder.Ignore(e => e.Id);
            builder.Ignore(e => e.Descricao);

            builder.Property(e => e.IdProduto).HasColumnName("id_produto").ValueGeneratedOnAdd();
            builder.Property(e => e.DataInvestimento).HasColumnName("din_investimento");
            builder.Property(e => e.ValorInvestido).HasColumnName("val_investido");
            builder.Property(e => e.ValorAtual).HasColumnName("val_atual");
            builder.HasOne(r => r.TipoProduto).WithMany(a => a.ProdutoLista).HasForeignKey(a => a.IdTipoProduto);
            builder.HasOne(r => r.SituacaoProduto).WithMany(a => a.ProdutoLista).HasForeignKey(a => a.IdSituacaoProduto);
            builder.HasOne(r => r.Cliente).WithMany(a => a.ProdutoLista).HasForeignKey(a => a.IdCliente);
        }
    }
}
