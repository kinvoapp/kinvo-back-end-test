using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.ValueObjects
{
    public class AmountMoney
    {
        public double Money { get; set; }

        public AmountMoney(double money)
        {
            Money = money;
        }
    }
}
