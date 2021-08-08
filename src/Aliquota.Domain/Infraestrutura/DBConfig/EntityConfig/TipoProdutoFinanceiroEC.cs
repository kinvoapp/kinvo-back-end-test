using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Aliquota.Domain.Infraestrutura.DBConfig.EntityConfig
{
    public class TipoProdutoFinanceiroEC : IEntityTypeConfiguration<TipoProdutoFinanceiro>
    {
        public void Configure(EntityTypeBuilder<TipoProdutoFinanceiro> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasDefaultValueSql("newid()");
            builder.Property(t => t.Nome).HasMaxLength(45).IsRequired();
            builder.Property(t => t.PorcentagemLucro).IsRequired();

            //Dados para teste
            builder.HasData(
                new TipoProdutoFinanceiro
                {
                    Id=Guid.NewGuid(),
                    Nome="CDB",
                    PorcentagemLucro=7
                },
                new TipoProdutoFinanceiro
                {
                    Id = Guid.NewGuid(),
                    Nome = "Poupança",
                    PorcentagemLucro = 3
                }
            );
        }
    }
}
