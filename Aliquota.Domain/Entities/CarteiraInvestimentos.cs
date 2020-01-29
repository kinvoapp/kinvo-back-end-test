using System;

namespace Aliquota.Domain.Entities
{
    public class CarteiraInvestimentos
    {
        public int IdCarteiraInvestimentos { get; set; }

        public ProdutoFinanceiro ProdutoFinanceiro { get; set; }

        public DateTime DataAplicado { get; set; }

        public decimal ValorAplicado { get; set; }

        public DateTime? DataResgate { get; set; }

        public decimal ValorBruto { get; set; }

        public decimal? ValorIR { get; set; }

        public decimal? ValorLiquido { get; set; }
    }
}
