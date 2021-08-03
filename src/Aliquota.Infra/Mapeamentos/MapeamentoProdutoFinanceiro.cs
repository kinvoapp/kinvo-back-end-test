using Aliquota.Domain.Entidades;
using Aliquota.Domain.Infra.Mapeamentos.Base;
using Aliquota.Domain.Infra.Mapeamentos.Configuracoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aliquota.Infra.Mapeamentos
{
    public class MapeamentoProdutoFinanceiro : MapeamentoBase<ProdutoFinanceiro>
    {
        public override void Configure(EntityTypeBuilder<ProdutoFinanceiro> builder)
        {
            builder.Property(x => x.Nome)
                .HasColumnType(MapeamentoDefinicoes.DBTYPE_NOME)
                .IsRequired();

            builder.Property(x => x.ValorCotacao)
                .HasColumnType(MapeamentoDefinicoes.DBTYPE_DECIMAL)
                .IsRequired();

            base.Configure(builder);
        }
    }
}