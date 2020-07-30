using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Models;

namespace src.Database.Mappings
{
    public class SaldoFundoMap : IEntityTypeConfiguration<SaldoFundo>
    {
        public void Configure(EntityTypeBuilder<SaldoFundo> builder)
        {
            builder.ToTable("saldo_fundo")
                .HasComment("Armazena os saldos do fundo por aplicação.");

            builder.HasKey(e => e.Id)
                .HasName("ix_saldo_fundo01");

            builder.Property(e => e.Id)
                .HasColumnName("seq_saldo_fundo")
                .HasColumnType("int")
                .HasComment("Sequencial que identifica unicamente o registro da tabela");

            builder.Property(e => e.DataReferencia)
                .HasColumnName("dtc_referencia")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .HasComment("Data de referencia do saldo ")
                .IsRequired(true);

            builder.Property(e => e.SaldoAtual)
                .HasColumnName("val_saldo_atual")
                .HasColumnType("decimal(18,2)")
                .HasComment("Valor bruto do resgate escolhido");

            builder.Property(e => e.SaldoAnterior)
                .HasColumnName("val_saldo_anterior")
                .HasColumnType("decimal(18,2)")
                .HasComment("Valor bruto do resgate escolhido");

            builder.Property(e => e.QuantidadeCotas)
                .HasColumnName("qtd_cotas_movimentada")
                .HasColumnType("decimal(18,2)")
                .HasComment("Quantidade de cotas movimentada na aplicação escolhida");

            builder.HasOne(e => e.AplicacaoFundo)
                .WithMany(m => m.SaldoFundos)
                .HasForeignKey(e => e.AplicacaoFundoId)
                .HasConstraintName("fk_saldo_fundo_aplicacao_fundo")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.FundoInvestimento)
                .WithMany(m => m.SaldoFundos)
                .HasForeignKey(e => e.FundoInvestimentoId)
                .HasConstraintName("fk_saldo_fundo_fundo_investimento")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}