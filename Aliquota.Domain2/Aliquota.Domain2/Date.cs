using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
    public class Date
    {
        public int mes;
        public int ano;

        public Date(int mes, int ano)
        {
            this.mes = mes;
            this.ano = ano;
        }
    }
}
