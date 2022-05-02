using Aliquota.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Entities
{
    public class FinancialProduct
    {
        public Guid FinancialProductID { get; set; }
        public FullName Name { get; set; }
        public ProductPercentage Percentage { get; set; }

        public FinancialProduct(Guid id, FullName name, ProductPercentage percentage)
        {
            FinancialProductID = id;
            Name = name;
            Percentage = percentage;
        }
    }
}
