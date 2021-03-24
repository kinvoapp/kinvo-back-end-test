using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Api.Services
{
    public class Meses 
    { 
        public static int Contar(DateTime date)
        {

            var ano = DateTime.Now.Year - date.Year;
            var meses = DateTime.Now.Month - date.Month;
            if (meses < 0)
            {
                meses = 12 + meses;
                ano--;
            }
            meses += ano * 12;
            return meses;

        }
    }
}
