using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Models
{
    public class ProcessaCalculo
    {
        public double CalculaImposto(DateTime dataAplicacao, DateTime dataResgate, double valorAplicado)
        {
            TimeSpan date = Convert.ToDateTime(dataResgate) - Convert.ToDateTime(dataAplicacao);
            int totalDias = date.Days;

            double lucroTotal = CalculaValorRendimento(dataAplicacao, dataResgate, valorAplicado);
            double impostoCalculado;

            if (totalDias > 730)
            {
                impostoCalculado = (lucroTotal * 15D)/100;
            }
            else if (totalDias >= 365 && totalDias <= 730)
            {
                impostoCalculado = (lucroTotal * 18.5D)/100;
            }
            else
            {
                impostoCalculado = (lucroTotal * 22.5D)/100;
            }

            return impostoCalculado;
        }

        public double CalculaValorRendimento(DateTime dataAplicacao, DateTime dataResgate, double valorAplicado)
        {
            TimeSpan date = Convert.ToDateTime(dataResgate) - Convert.ToDateTime(dataAplicacao);
            int totalMeses = (date.Days / 30);
            double jurosMensal = (1.5D / 100);
            double lucroTotal = 0;
            for (int i = 0; i < totalMeses; i++)
            {
                if (i == 0)
                {
                    lucroTotal = (valorAplicado * jurosMensal) + valorAplicado;

                }
                else
                {
                    lucroTotal = (lucroTotal * jurosMensal) + lucroTotal;
                }
            }

            double valorRendimento = lucroTotal;
            return valorRendimento;
        }
    }
}
