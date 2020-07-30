using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.Models;

namespace src.Database.Mappings
{
    public class FundoInvestimentoMap : IEntityTypeConfiguration<FundoInvestimento>
    {
        public void Configure(EntityTypeBuilder<FundoInvestimento> builder)
        {
            builder.ToTable("fundo_investimento")
                .HasComment("Armazena os fundos de investimento da aplicacao ");

            builder.HasKey(e => e.Id)
                .HasName("ix_fundo_investimento01");

            builder.Property(e => e.Id)
                .HasColumnName("seq_aplicacao_fundo")
                .HasColumnType("int")
                .HasComment("Sequencial que identifica unicamente o registro da tabela");

            builder.Property(e => e.NomeAtivo)
                .HasColumnName("des_nome_ativo")
                .HasMaxLength(255)
                .HasColumnType("varchar")
                .IsRequired(true)
                .HasComment("Campo contendo nome do ativo");

            //Deve ser uma tabela de dominio  de Pessoa Juridica
            builder.Property(e => e.Administrador)
                .HasColumnName("des_administrador")
                .HasMaxLength(255)
                .HasColumnType("varchar")
                .IsRequired(true)
                .HasComment("Campo  nome do administrador do fundo");

            //Deve ser uma tabela de dominio de indicadores
            builder.Property(e => e.IndicadorDesempenho)
                .HasColumnName("des_indicador_desempenho")
                .HasMaxLength(255)
                .HasColumnType("varchar")
                .IsRequired(true)
                .HasComment("Campo  nome do indicador de desempenho do fundo");

            //Deve ser uma tabela de dominio de tipos fundos (Multimercado, renda fixa, cambial e etc.)
            builder.Property(e => e.TipoFundo)
                .HasColumnName("des_tipo_fundo")
                .HasMaxLength(255)
                .HasColumnType("varchar")
                .IsRequired(true)
                .HasComment("Campo  nome do indicador de desempenho do fundo");

            //Deve ser uma tabela de dominio  de Pessoa Juridica
            builder.Property(e => e.Cnpj)
                .HasColumnName("num_cnpj")
                .HasColumnType("int")
                .IsRequired(true)
                .HasComment("Campo contendo cnpj do ativo");

            builder.Property(e => e.DataEmissao)
                .HasColumnName("dtc_referencia")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .HasComment("Data de emissão do ativo")
                .IsRequired(true);

            builder.Property(e => e.CotaFundo)
                .HasColumnName("val_cota_fundo")
                .HasColumnType("decimal(18,2)")
                .HasComment("Valor da cota fundo");

            builder.Property(e => e.isFundoCotas)
                 .HasColumnName("sts_fundo_cotas");

            builder.Property(e => e.isFundoExclusivo)
                .HasColumnName("sts_fundo_exclusivo");

            builder.Property(e => e.isTratamentoTributarioLongoPrazo)
                .HasColumnName("sts_tratamento_tributario_longoPrazo");

            builder.Property(e => e.isDestinadoInvestidoresQualificados)
                .HasColumnName("sts_destinado_investidores_qualificados");

            builder.HasMany(e => e.AplicacoesFundo)
                .WithOne()
                .HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
