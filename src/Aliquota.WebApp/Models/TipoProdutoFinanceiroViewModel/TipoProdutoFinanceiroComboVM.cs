using Aliquota.Domain.Models;
using System;

namespace Aliquota.WebApp.Models.TipoProdutoFinanceiroViewModel
{
    public class TipoProdutoFinanceiroComboVM
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public TipoProdutoFinanceiroComboVM(TipoProdutoFinanceiro tipoProdutoFinanceiro)
        {
            Id = tipoProdutoFinanceiro.Id;
            Nome = tipoProdutoFinanceiro.Nome;
        }
    }
}
