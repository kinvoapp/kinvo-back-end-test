using System;

namespace Aliquota.Domain.DTOs
{
    public class AplicacaoFinanceiraResgatada
    {
        public DateTime DataAplicacao { get; internal set; }
        public decimal ValorAplicado { get; internal set; }
        public decimal LucroLiquido { get; internal set; }
        public decimal PercentualImpostoRenda { get; internal set; }
    }
}