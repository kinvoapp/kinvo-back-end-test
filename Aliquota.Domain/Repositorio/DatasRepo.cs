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
            int total = (dataResgate.Year - dataAplicacao.Year) + dataAplicacao.Month + dataResgate.Month;

            return total;
        }
    }
}
