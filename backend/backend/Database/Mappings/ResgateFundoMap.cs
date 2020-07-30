using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Models;

namespace src.Database.Mappings
{
    public class ResgateFundoMap : IEntityTypeConfiguration<ResgateFundo>
    {
        public void Configure(EntityTypeBuilder<ResgateFundo> builder)
        {
            builder.ToTable("resgate_fundo")
                .HasComment("Armazena os regaste feitos num fundo de investimento.");

            builder.HasKey(e => e.Id)
                .HasName("ix_resgate_fundo01");

            builder.Property(e => e.Id)
                .HasColumnName("seq_resgate_fundo")
                .HasColumnType("int")
                .HasComment("Sequencial que identifica unicamente o registro da tabela");

            builder.Property(e => e.DataReferencia)
                .HasColumnName("dtc_referencia")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .HasComment("Data de referencia do resgate ")
                .IsRequired(true);

            builder.Property(e => e.ValorResgateBruto)
                .HasColumnName("val_resgate_bruto")
                .HasColumnType("decimal(18,2)")
                .HasComment("Valor bruto do resgate escolhido");

            builder.Property(e => e.ValorResgateLiquido)
                .HasColumnName("val_resgate_liquido")
                .HasColumnType("decimal(18,2)")
                .HasComment("Valor da aplicacao escolhida");

            builder.Property(e => e.QuantidadeCotasResgatada)
                .HasColumnName("qtd_cotas_movimentada")
                .HasColumnType("decimal(18,2)")
                .HasComment("Quantidade de cotas movimentada na aplicação escolhida");

            builder.HasOne(e => e.AplicacaoFundo)
                .WithMany(m => m.ResgatesFundo)
                .HasForeignKey(e => e.AplicacaoFundoId)
                .HasConstraintName("fk_resgate_fundo_aplicacao_fundo")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.FundoInvestimento)
                .WithMany(m => m.ResgatesFundo)
                .HasForeignKey(e => e.FundoInvestimentoId)
                .HasConstraintName("fk_resgate_fundo_fundo_investimento")
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
