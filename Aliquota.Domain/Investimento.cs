using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain
{
    public class Investimento
    {
        public int Id { get; set; }
        public int Lucro { get; set; }
        public int TempoEmAnos { get;set; }
        public int TempoEmDias { get; set; }
        //public DateTime DataDeInicio { get; internal set; }
        //public DateTime DataDeResgate { get; internal set; }
    }
}