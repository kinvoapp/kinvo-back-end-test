using Aliquota.Domain.Models;
using Aliquota.WebApp.Models.ProdutoFinanceiroViewModel;
using Aliquota.WebApp.Models.TipoProdutoFinanceiroViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Aliquota.WebApp.Extensoes
{
    public static class ConversaoColecoes
    {
        public static IEnumerable<ProdutoFinanceiroVM> ConverteParaViewModel(this IEnumerable<ProdutoFinanceiro> produtosFinanceiros)
        => produtosFinanceiros.Select(p => new ProdutoFinanceiroVM(p));

        public static IEnumerable<TipoProdutoFinanceiroComboVM> ConverteParaViewModel(this IEnumerable<TipoProdutoFinanceiro> tiposprodutoFinanceiro)
        => tiposprodutoFinanceiro.Select(t => new TipoProdutoFinanceiroComboVM(t));
    }
}
