using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Entitys
{
    public class Invest
    {
        public int InvestId { get; set; }
        public Client Client { get; set; }
        public double InvestedValue { get; set; }
        public DateTime AppDate { get; set; }
    }
}
