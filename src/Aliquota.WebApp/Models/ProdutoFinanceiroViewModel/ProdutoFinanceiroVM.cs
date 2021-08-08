using Aliquota.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.WebApp.Models.ProdutoFinanceiroViewModel
{
    public class ProdutoFinanceiroVM
    {
        public Guid Id { get; }
        public string Nome { get; }
        public Status Status { get;}
        [Display(Name="Valor Aplicado")]
        public double ValorAplicado { get; }
        public double Lucro { get; }
        [Display(Name = "Data da Aplicação")]
        public string DataAplicacao { get; }
        [Display(Name = "Data do Resgate")]
        public string DataResgate { get; }
        [Display(Name = "Valor do IR")]
        public double ValorIR { get; }

        public ProdutoFinanceiroVM(ProdutoFinanceiro produtoFinanceiro)
        {
            Id = produtoFinanceiro.Id;
            Nome = produtoFinanceiro.TipoProdutoFinanceiro.Nome;
            Status = produtoFinanceiro.Status;
            ValorAplicado = produtoFinanceiro.ValorAplicado;
            Lucro = produtoFinanceiro.Lucro;
            ValorIR = produtoFinanceiro.ValorIR;
            DataAplicacao = produtoFinanceiro
                                        .DataAplicacao
                                                .ToString("dd/MM/yyyy");
            if (produtoFinanceiro.DataResgate.HasValue)
                DataResgate = produtoFinanceiro
                                        .DataResgate.Value
                                                .ToString("dd/MM/yyyy");
            else
                DataResgate = "Vazio";
        }
    }
}
