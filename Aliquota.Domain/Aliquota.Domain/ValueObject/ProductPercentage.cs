using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.ValueObjects
{
    public class ProductPercentage
    {
        public double Percentage { get; set; }

        public ProductPercentage(double percentage)
        {
            Percentage = percentage;
        }
    }
}
