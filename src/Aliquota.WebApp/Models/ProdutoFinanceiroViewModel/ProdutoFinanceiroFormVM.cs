using Aliquota.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.WebApp.Models.ProdutoFinanceiroViewModel
{
    public class ProdutoFinanceiroFormVM
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [Display(Name = "Valor Aplicado")]
        [Range(1,double.MaxValue,ErrorMessage ="O campo Valor Aplicado deve ser maior que zero.")]
        public double ValorAplicado { get; set; }
        [Display(Name = "Tipo do Produto Financeiro")]
        [Required(ErrorMessage = "O campo Tipo do Produto Financeiro é obrigatório")]
        public Guid TipoProdutoFinanceiroFk { get; set; }

        public ProdutoFinanceiro ConverteParaEntidade()
        => new ProdutoFinanceiro
        {
            ValorAplicado=this.ValorAplicado,
            TipoProdutoFinanceiroFK=this.TipoProdutoFinanceiroFk
        };
    }
}
