using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.ImpostoRenda
{
    public interface IImpostoRenda
    {
        TimeSpan PeriodoInvestimento();
        decimal Lucro();
        public decimal PercentualIR { get; set; }
        public decimal ValorIR { get; set; }
    }
}
