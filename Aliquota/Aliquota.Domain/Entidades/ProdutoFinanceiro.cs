using System;

namespace Aliquota.Domain.Entidades
{
    public class ProdutoFinanceiro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double ValorAplicado { get; set; }
        public DateTime DataInvestimento { get; set; }
        public DateTime TempoInvestido { get; set; }

    }
}
