using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Models;

namespace src.Database.Mappings
{
    public class AplicacaoFundoMap : IEntityTypeConfiguration<AplicacaoFundo>
    {
        public void Configure(EntityTypeBuilder<AplicacaoFundo> builder)
        {
            builder.ToTable("aplicacao_fundo")
                .HasComment("Armazena as aplicacoes feitas no produto.");

            builder.HasKey(e => e.Id)
                .HasName("ix_aplicacao_fundo01");

            builder.Property(e => e.Id)
                .HasColumnName("seq_aplicacao_fundo")
                .HasColumnType("int")
                .HasComment("Sequencial que identifica unicamente o registro da tabela");

            builder.Property(e => e.DataReferencia)
                .HasColumnName("dtc_referencia")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .HasComment("Data de atualização do registro")
                .IsRequired(true);

            builder.Property(e => e.DataReferencia)
                .HasColumnName("dtc_referencia")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .HasComment("Data de referencia da aplicacao")
                .IsRequired(true);

            builder.Property(e => e.ValorAplicacao)
                .HasColumnName("val_aplicacao")
                .HasColumnType("decimal(18,2)")
                .HasComment("Valor da aplicacao escolhida");


            builder.Property(e => e.QuantidadeCotas)
                .HasColumnName("qtd_cotas_movimentada")
                .HasColumnType("decimal(18,2)")
                .HasComment("Quantidade de cotas movimentada na aplicação escolhida");

            builder.HasOne(e => e.FundoInvestimento)
                .WithMany(m => m.AplicacoesFundo)
                .HasForeignKey(e => e.FundoInvestimentoId)
                .HasConstraintName("fk_aplicacao_fundo_fundo_investimento")
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
