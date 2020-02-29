using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.ImpostoRenda
{
    public class CalcularImpostoRenda : ICalcularImposto
    {
        public void Calcular(IImpostoRenda impostoRenda)
        {
            if (impostoRenda.Lucro() == 0.00M)
                return;

            if (impostoRenda.PeriodoInvestimento().TotalDays <= 366)
            {
                impostoRenda.PercentualIR = 22.5M;
            }
            else if (impostoRenda.PeriodoInvestimento().TotalDays <= 732)
            {
                impostoRenda.PercentualIR = 18.5M;
            }
            else
            {
                impostoRenda.PercentualIR = 15.00M;
            }

            impostoRenda.ValorIR = impostoRenda.Lucro() * (impostoRenda.PercentualIR / 100);

        }
    }
}
