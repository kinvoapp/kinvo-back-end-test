using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Entities
{
    public class Investment
    {
        public int ID { get; set; }
        public decimal Value { get; set; }
        public decimal Profit { get; set; }
        public DateTime Application { get; set; }
    }
}
