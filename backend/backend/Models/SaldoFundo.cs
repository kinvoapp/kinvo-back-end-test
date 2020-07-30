using System;
using System.ComponentModel.DataAnnotations;

namespace src.Models
{
    public class SaldoFundo
    {
        public int Id { get; set; }

        public int AplicacaoFundoId { get; set; }

        public virtual AplicacaoFundo AplicacaoFundo { get; set; }

        public int FundoInvestimentoId { get; set; }

        public virtual FundoInvestimento FundoInvestimento { get; set; }

        public decimal SaldoAnterior { get; set; }

        public decimal SaldoAtual { get; set; }

        public decimal QuantidadeCotas { get; set; }

        public DateTime DataReferencia { get; set; }

    }
}
