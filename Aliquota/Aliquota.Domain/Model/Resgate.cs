using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Model
{
    public class Resgate
    {
        public int ID { get; set; }
        public decimal VlResgate { get; set; }
        public DateTime DataResgate { get; set; }
        public int VlImposto { get; set; }
        public int InvestimentoID { get; set; }
        public int ClienteID { get; set; }


    }
}
