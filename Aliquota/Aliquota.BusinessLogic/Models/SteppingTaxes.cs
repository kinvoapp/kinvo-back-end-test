using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.BusinessLogic.Models
{
    public class SteppingTaxes
    {
        private SortedList<Decimal, Decimal> Steps;
        SteppingTaxes(IDictionary<Decimal, Decimal> dick)
        {
            this.Steps = new SortedList<Decimal, Decimal>(dick);
        }
        Decimal GetTax(decimal value)
        {
            IEnumerator<KeyValuePair<Decimal, Decimal>> enumerator = this.Steps.GetEnumerator();
            KeyValuePair<Decimal, Decimal> closest = new KeyValuePair<Decimal, Decimal>(value,0);
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.Key > closest.Key)
                    break;
                closest = enumerator.Current;
            }
            return closest.Value;
        }
    }

}
