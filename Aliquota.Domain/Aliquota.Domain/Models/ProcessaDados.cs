using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Models
{
    public class ProcessaDados
    {
        public double CalculaImpostoDevido(DateTime dataAplicacao, DateTime dataResgate, double valorRendimento)
        {
            int TotalDias = RetornaQtdDias(dataResgate, dataAplicacao);

            double IRSobreRendimento;

            if (TotalDias > 730)
            {
                IRSobreRendimento = (valorRendimento * 15D)/100;
            }
            else if (TotalDias >= 365 && TotalDias <= 730)
            {
                IRSobreRendimento = (valorRendimento * 18.5D)/100;
            }
            else
            {
                IRSobreRendimento = (valorRendimento * 22.5D)/100;
            }

            return IRSobreRendimento;
        }

        public double CalculaValorRendimento(DateTime dataAplicacao, DateTime dataResgate, double valorAplicado)
        {
            int TotalMeses = RetornaQtdMeses(dataResgate, dataAplicacao);
            double JurosMensal = (1.5D / 100);
            double LucroTotal = 0;

            for (int i = 0; i < TotalMeses; i++)
            {
                if (i == 0)
                {
                    LucroTotal = (valorAplicado * JurosMensal) + valorAplicado;
                }
                else
                {
                    LucroTotal = (LucroTotal * JurosMensal) + LucroTotal;
                }
            }

            double ValorRendimento = (LucroTotal - valorAplicado);
            return ValorRendimento;
        }

        public int RetornaQtdDias(DateTime dataFinal, DateTime dataInicial)
        {
            TimeSpan Date = Convert.ToDateTime(dataFinal) - Convert.ToDateTime(dataInicial);
            int TotalDias = Date.Days;

            return TotalDias;
        }

        public int RetornaQtdMeses(DateTime dataFinal, DateTime dataInicial)
        {
            TimeSpan Date = Convert.ToDateTime(dataFinal) - Convert.ToDateTime(dataInicial);
            int TotalMeses = (Date.Days / 30);

            return TotalMeses;
        }
    }
}
