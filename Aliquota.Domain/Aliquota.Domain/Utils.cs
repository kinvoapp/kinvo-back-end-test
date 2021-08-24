using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain
{
    public static class Utils
    {
        public struct DiferencaDatas
        {
            public int dias;
            public int meses;
            public int anos;
        }
        public static DiferencaDatas CalculaDiferencaDatas(DateTime dataMaior, DateTime dataMenor)
        {
            int anos = dataMaior.Year - dataMenor.Year;
            int meses = dataMaior.Month - dataMenor.Month;
            int dias = dataMaior.Day - dataMenor.Day;
            int totalMeses = (anos * 12 + meses);
            if (dias < 0 && totalMeses > 0) totalMeses--;
            int totalDias = Convert.ToInt32((dataMaior - dataMenor).TotalDays);
            int totalAnos = totalMeses / 12;
            return new DiferencaDatas { dias = totalDias, meses = totalMeses, anos = totalAnos };
        }
    }
}
