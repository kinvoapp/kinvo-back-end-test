using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Shared.Utils
{
    public static class Utilitarios
    {
        #region Converte Juros

        private static double ConverteJuros(double taxa, double tempo, int precisao=2)
        {
            taxa = taxa / 100;
            var result = (((Math.Pow((1 + taxa), tempo)) - 1)) * 100;
            return Math.Round(result, precisao);
        }

        public static double ConverteJurosAnoMes(double taxa)
        {
            return ConverteJuros(taxa, (1.0/12), 2);
        }

        public static double ConverteJurosAnoDia(double taxa)
        {
            return ConverteJuros(taxa, (1.0/360), 4);
        }

        public static double ConverteJurosMesAno(double taxa)
        {
            return ConverteJuros(taxa, 12.0);
        }

        public static double ConverteJurosMesDia(double taxa)
        {
            return ConverteJuros(taxa, (1.0/30), 4);
        }

        public static double ConverteJurosDiaMes(double taxa)
        {
            return ConverteJuros(taxa, 30.0);
        }

        public static double ConverteJurosDiaAno(double taxa)
        {
            return ConverteJuros(taxa, 360.0);
        }

        #endregion

        #region Rendimento

        public static decimal CalculaRentabilidade(double valorAplicado, double juros, int meses)
        {
            var jurosMes = ConverteJurosAnoMes(juros);
            var rentabilidade = valorAplicado * Math.Pow((1 + jurosMes/100), meses);
            return (decimal)Math.Round(rentabilidade, 2);
        }

        #endregion

        #region Datas

        /*      Caso a data inicial seja menor que a data de retirada, retorna verdadeiro, se for 
         * igual ou superior retorna falso.
         */
        public static bool VerificaDatas(DateTime inicio, DateTime retirada)
        {
            return (DateTime.Compare(inicio, retirada) < 0);
        }

        public static int CalculaDias(DateTime inicio, DateTime retirada)
        {
            TimeSpan data = retirada - inicio;
            return data.Days;
        }

        #endregion

        #region Imposto de Renda

        public static double CalculaAliquota(int quantidadeDias)
        {
            double aliquota;
            if(quantidadeDias <= 365) { aliquota = 22.5; }
            else if(quantidadeDias <= 730) { aliquota = 18.5; }
            else { aliquota = 15.0; }
            return aliquota;
        }

        public static decimal ImpostoDeRenda(double valor, double aliquota)
        {
            var ir = (valor * aliquota) / 100;
            return (decimal)Math.Round(ir, 2);
        }
        #endregion
    }
}
