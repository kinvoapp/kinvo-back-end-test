using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Aliquota.Infra.Data.Mappings
{
    public class ContaMap : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("conta");

            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.ValorAplicacao)
                .HasColumnName("valorAplicacao")
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(c => c.ValorCorrente)
                .HasColumnName("valorCorrente")
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(c => c.DtAplicacao)
                .HasColumnName("dtAplicacao")
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(c => c.DtResgate)
                .HasColumnName("dtResgate")
                .HasColumnType("datetime2");

            builder.Property(c => c.ValorResgate)
                   .HasColumnName("valorResgate")
                   .HasColumnType("decimal(10,2)");

            builder.Property(c => c.Ativo)
                .HasColumnName("ativo");

            builder.HasData(
                new Conta
                {
                    Nome = "Marcelo Pereira",
                    ValorAplicacao = 400.00m,
                    ValorCorrente = 1200.00m,
                    DtAplicacao = new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                },
                new Conta
                {
                    Nome = "Nayra Gomes",
                    ValorAplicacao = 700.00m,
                    ValorCorrente = 2100.00m,
                    DtAplicacao = new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                },
                new Conta
                {
                    Nome = "Daniele Ramos",
                    ValorAplicacao = 600.00m,
                    ValorCorrente = 1800.00m,
                    DtAplicacao = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                },
                new Conta
                {
                    Nome = "Anderson Silva",
                    ValorAplicacao = 200.00m,
                    ValorCorrente = 600.00m,
                    DtAplicacao = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                },
                new Conta
                {
                    Nome = "Mariana Santos",
                    ValorAplicacao = 800.00m,
                    ValorCorrente = 2400.00m,
                    DtAplicacao = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                },
                new Conta
                {
                    Nome = "José Henrique",
                    ValorAplicacao = 900.00m,
                    ValorCorrente = 2700.00m,
                    DtAplicacao = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}
