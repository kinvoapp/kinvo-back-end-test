using Alicota.Controller;
using Alicota.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alicota.Utils
{
    class Calcula
    {
        public static void Alicota(decimal valorAplicado, decimal valorResgatado, DateTime dataAplicacao, DateTime dataResgate)
        {
            double dias = dataResgate.Subtract(dataAplicacao).TotalDays;
            decimal totalRedimento = 0, totalDesconto = 0;

            if (dias <= 365)
            {
                totalRedimento = valorResgatado - valorAplicado;
                totalDesconto = totalRedimento * 0.255M;
                totalRedimento -= totalDesconto;
                Console.WriteLine(String.Format("Total de rendimneto com desconto {0}\n Total do desconto do IR {1}", totalRedimento.ToString("C"), totalDesconto.ToString("C")));
            }
            else if(dias > 365 || dias <= 730)
            {
                totalRedimento = valorResgatado - valorAplicado;
                totalDesconto = totalRedimento * 0.185M;
                totalRedimento -= totalDesconto;
                Console.WriteLine(String.Format("Total de rendimneto com desconto {0}\n Total do desconto do IR {1}", totalRedimento.ToString("C"), totalDesconto.ToString("C")));


            }
            else if(dias > 730)
            {
                totalRedimento = valorResgatado - valorAplicado;
                totalDesconto = totalRedimento * 0.185M;
                totalRedimento -= totalDesconto;
                Console.WriteLine(String.Format("Total de rendimneto com desconto {0}\n Total do desconto do IR {1}\n ", totalRedimento.ToString("C"), totalDesconto.ToString("C")));
            }
            

        }
    }
}
