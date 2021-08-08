using NodaTime;
using System;

namespace Aliquota.Domain.Extensoes
{
    public static class ComparaDatas
    {
        public static int DiferencaDataAplicacaoEmMeses(this DateTime dataAplicacao, DateTime? dataResgate)
        {
            var dataFinal = (dataResgate.HasValue) ? 
                            LocalDate.FromDateTime(dataResgate.Value) :
                            LocalDate.FromDateTime(DateTime.Now);
            var dataAplicacaoConvertida = LocalDate.FromDateTime(dataAplicacao);
            Period period = Period.Between(dataAplicacaoConvertida, dataFinal,PeriodUnits.Months);
            if (period.Months == 0) return 1;
            return period.Months;
        }
    }
}
