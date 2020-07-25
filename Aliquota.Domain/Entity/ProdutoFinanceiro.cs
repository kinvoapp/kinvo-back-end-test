using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Entity
{
    public class ProdutoFinanceiro : EntityBase
    {
        public ProdutoFinanceiro() { }
        public ProdutoFinanceiro(string descricao, decimal taxaRendimento)
        {
            Descricao = descricao;
            TaxaRedendimento = taxaRendimento;
        }
        public string Descricao { get; set; }
        public decimal TaxaRedendimento { get; set; }
    }
}
