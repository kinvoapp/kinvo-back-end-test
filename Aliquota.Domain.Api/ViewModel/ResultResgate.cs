using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Api.ViewModel
{
    public class ResultResgate
    {
        public ResultResgate()
        {
        }

        public decimal IR { get; set; }
        public decimal LucroBruto { get; set; }
        public decimal LucroLiquido { get; set; }
        public decimal TotalReagate { get; set; }
    }
}
