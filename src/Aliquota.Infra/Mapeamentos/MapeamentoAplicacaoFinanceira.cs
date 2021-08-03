using Aliquota.Domain.Entidades;
using Aliquota.Domain.Infra.Mapeamentos.Base;
using Aliquota.Domain.Infra.Mapeamentos.Configuracoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aliquota.Domain.Infra.Mapeamentos
{
    public class MapeamentoAplicacaoFinanceira : MapeamentoBase<AplicacaoFinanceira>
    {
        public override void Configure(EntityTypeBuilder<AplicacaoFinanceira> builder)
        {
            builder.Property(x => x.DataAplicacao)
                .HasColumnType(MapeamentoDefinicoes.DBTYPE_DATETIME)
                .IsRequired();

            builder.Property(x => x.Quantidade)
                .HasColumnType(MapeamentoDefinicoes.DBTYPE_DECIMAL)
                .IsRequired();

            builder.Property(x => x.ValorAplicacao)
                .HasColumnType(MapeamentoDefinicoes.DBTYPE_DECIMAL)
                .IsRequired();

            builder.Ignore(x => x.Lucro);

            base.Configure(builder);
        }
    }
}