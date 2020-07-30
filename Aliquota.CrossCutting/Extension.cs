using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Aliquiota.CrossCutting
{
    public static class Extension
    {
        public static double CalcularJurosCompostos(this double montante, double taxa, DateTime dataInicial, DateTime? dataFinal = null)
        {
            var numDias = ((dataFinal ?? DateTime.Now) - dataInicial).Days;
            return montante * Math.Pow((1 + taxa), numDias);

        }

        public static double CalcularIR(this double valorBruto, double valorAplicado, DateTime dataInicial, DateTime? dataFinal = null)
        {
            var taxaIR = dataInicial.CalcularAliquotaIR(dataFinal);
            return valorBruto - ((valorBruto - valorAplicado) * taxaIR);
        }

        public static double CalcularAliquotaIR(this DateTime dataInicial, DateTime? dataFinal)
        {
            int tempo = ((dataFinal ?? DateTime.Now) - dataInicial).Days;
            double taxaIR = 0;

            if (tempo >= 0 && tempo <= 365)
                taxaIR = 0.225;
            else if (tempo > 365 && tempo <= 730)
                taxaIR = 0.185;
            else if (tempo > 730)
                taxaIR = 0.15;

            return taxaIR;
        }

        public static void IsValid(this IValidatableObject obj)
        {
            if (obj == null)
                return;

            var result = obj.Validate(null);

            if (result.Any())
                throw new ApplicationException(result.First().ErrorMessage);
        }
    }
}
