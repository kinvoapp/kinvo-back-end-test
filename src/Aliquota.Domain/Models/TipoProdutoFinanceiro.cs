using System;

namespace Aliquota.Domain.Models
{
    public class TipoProdutoFinanceiro
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double PorcentagemLucro { get; set; }
    }
}
