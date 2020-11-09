using Aliquota.Domain.Entities;
using System;

namespace Aliquota.Domain.DTOs
{
    public class AplicacaoFinanceiraDTO
    {
        public string Nome { get; set; }

        public decimal ValorAplicado { get; set; }

        public decimal TaxaRendimento { get; set; }

        public DateTime DataAplicacao { get; set; }

        public AplicacaoFinanceira ConverterDtoParaEntity()
        {
            return new AplicacaoFinanceira()
            {
                Nome = this.Nome,
                ValorAplicado = this.ValorAplicado,
                TaxaRendimento = this.TaxaRendimento,
                DataAplicacao = this.DataAplicacao
            };
        }
    }
}
