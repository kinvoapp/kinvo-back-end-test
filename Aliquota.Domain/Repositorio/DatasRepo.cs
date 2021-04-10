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
    }
}
