using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
    public class CalcularAliquota
    {
    

        private decimal lucro;
        private decimal lucroTotal;
        private double impostoSobreLucro;


        public CalcularAliquota()
        {
            
        }

        public void GetAliquota(decimal ValorAplicado, DateTime DataDeResgate, DateTime DataDeAplicacao)
        {
            
            decimal dias = (decimal)DataDeResgate.Subtract(DataDeAplicacao).TotalDays;

            
            decimal rendimento = CalcularRendimento(ValorAplicado, dias);

            Console.WriteLine($"\nResumo: \n Valor Aplicado: {ValorAplicado} \n Valor Resgatado: {rendimento}\n Rendimento: R${Math.Round(lucro)}\n Lucro Total: R${Math.Round(lucroTotal)} \n " +
                    $"Imposto sobre o lucro: {impostoSobreLucro}% ");
            
            
        }

        public decimal CalcularRendimento(decimal ValorAplicado, decimal dias)
        {

            if(dias <= 365)
            {
                lucro = ValorAplicado * 0.05M;
                lucroTotal = lucro;
                decimal imposto = lucro * 0.225M;
                lucro = lucro - imposto;
                ValorAplicado = Math.Round(ValorAplicado + lucro, 2);
                impostoSobreLucro = 22.5;
            }
            else if(dias > 365 && dias <= 730)
            {
                lucro = ValorAplicado * 0.1M;
                lucroTotal = lucro;
                decimal imposto = lucro * 0.185M;
                lucro = lucro - imposto;
                ValorAplicado = Math.Round(ValorAplicado + lucro, 2);
                impostoSobreLucro = 18.5;
            }
            else
            {
                lucro = ValorAplicado * 0.3M;
                lucroTotal = lucro;
                decimal imposto = lucro * 0.15M;
                lucro = lucro - imposto;
                ValorAplicado = Math.Round(ValorAplicado + lucro, 2);
                impostoSobreLucro = 15;
            }

            return ValorAplicado;
        }

        





    }
}
