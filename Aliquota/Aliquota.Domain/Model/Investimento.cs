using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Model
{
    public class Investimento
    {
        public int ID { get; set; }
        public decimal VlInvest { get; set; }
        public DateTime DataAplicacao { get; set; }
        public int ClienteID { get; set; }
        public decimal PercentLucro { get; set; }

    }
}
