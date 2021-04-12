using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Repositorio
{
    class DatasRepo
    {
        public int CalcularMesesAplicado(DateTime dataAplicacao, DateTime dataResgate)
        {
            var total = dataResgate.Subtract(dataAplicacao);
            int meses = (int)total.Days / 30;
            return meses;
        }

        public int CalcularMesesAplicadosComHistorico(Aplicacoes aplicacao, Resgates resgate)
        {
            int totalMeses = 0;
            if (aplicacao.Hisotricos.Count > 0)
            {
                List<Historicos> hist = aplicacao.Hisotricos.OrderBy(p => p.Id).ToList();
                totalMeses = CalcularMesesAplicado(hist[0].Data, resgate.Data);
            }
            else
            {
                totalMeses = CalcularMesesAplicado(aplicacao.Data, resgate.Data);
            }
            return totalMeses;
        }
    }
}
