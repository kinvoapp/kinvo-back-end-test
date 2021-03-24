using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Api.Services
{
    public class ImpostoRenda
    {
        public static decimal Aplicar(int meses)
        {
            // Aplicação com 1 ano       
            if (meses <= 12)
            {
                return 22.5M;
            }
            // Aplicação entre 1 a 2 anos
            else if (meses > 12 && meses <= 24)
            {
                return 18.5M;
            }
            // Aplicação acima de 2 anos 
            else
            {
                return 15M;
            }
        }
    }
}
