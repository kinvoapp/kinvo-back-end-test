﻿using System;
using System.ComponentModel.DataAnnotations;

namespace src.Models

{
    public class ResgateFundo
    {
        public int Id { get; set; }

        public DateTime DataReferencia { get; set; }

        public float ValorResgateBruto  { get; set; }

        public float ValorResgateLiquido { get; set; }

        [Required]
        public int FundoInvestimentoId { get; set; }

        public virtual FundoInvestimento FundoInvestimento { get; set; }

        [Required]
        public int AplicacaoFundoId { get; set; }

        public virtual AplicacaoFundo AplicacaoFundo { get; set; }

        public decimal QuantidadeCotasResgatada { get; set; }
    }
}
