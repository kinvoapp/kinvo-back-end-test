using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using backend;

namespace src.Models
{
    public class AplicacaoFundo
    {
        public int Id { get; set; }

        public DateTime DataReferencia { get; set; }

        public decimal ValorAplicacao { get; set; }

        public int FundoInvestimentoId { get; set; }

        public virtual FundoInvestimento FundoInvestimento { get; set; }

        public decimal QuantidadeCotas { get; set; }

        public virtual ICollection<ResgateFundo> ResgatesFundo { get; set; }
        public virtual ICollection<SaldoFundo> SaldoFundos { get; set; }
    }
}
