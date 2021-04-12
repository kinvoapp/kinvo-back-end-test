using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Repositorio
{
    public class LucroRepo
    {
        public double CalcularLucroTotal(Aplicacoes aplicacao, int totalMeses)
        {
            double valorTotal = aplicacao.Valor;
            double valorAntigo = aplicacao.Valor;

            for(int i = 0; i < totalMeses; i++)
            {
                valorTotal += valorAntigo * (aplicacao.Rentabilidade_Mes / 100);
                valorAntigo = valorTotal;
            }            

            if(aplicacao.Hisotricos != null)
                if(aplicacao.Hisotricos.Count > 0)
                {
                    foreach (Historicos h in aplicacao.Hisotricos)
                        valorTotal += h.Lucro;
                }

            return valorTotal - aplicacao.Valor;

        }

        public double CalcularValorIR(int totalMeses, double lucroTotal)
        {
            if (totalMeses <= 12)
            {
                return lucroTotal * (22.5 / 100);
            }
            else if(totalMeses > 12 && totalMeses <= 24)
            {
                return lucroTotal * (18.5 / 100);
            }
            else if(totalMeses > 24)
            {
                return  lucroTotal * (15.0 / 100);
            }

            return 0;
        }
    }
}
