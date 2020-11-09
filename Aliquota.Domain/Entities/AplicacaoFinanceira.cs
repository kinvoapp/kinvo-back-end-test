using System;

namespace Aliquota.Domain.Entities
{
    public class AplicacaoFinanceira
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal ValorAplicado { get; set; }

        public decimal TaxaRendimento { get; set; }

        public DateTime DataAplicacao { get; set; }

        public DateTime? DataResgate { get; set; }

        public double? ValorRendimentoBruto { get; set; }

        public double? ValorImpostoDeRendaRecolhido { get; set; }

        public double? ValorRendimentoLiquido => ValorRendimentoBruto - ValorImpostoDeRendaRecolhido;
    }
}
