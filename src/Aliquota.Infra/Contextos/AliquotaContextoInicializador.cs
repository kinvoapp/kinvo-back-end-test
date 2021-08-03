using Aliquota.Domain.Entidades;
using System.Linq;

namespace Aliquota.Infra.Contextos
{
    public static class AliquotaContextoInicializador
    {
        public static void IniciarBancoDeDados(this AliquotaContexto contexto)
        {
            if (contexto.ProdutoFinanceiros.Any())
                return;

            contexto.ProdutoFinanceiros.Add(new ProdutoFinanceiro(nome: "Tesouro Direto", valorCotacao: 100m, rendimentoMensal: 0.4m));
            contexto.SaveChanges();
        }
    }
}