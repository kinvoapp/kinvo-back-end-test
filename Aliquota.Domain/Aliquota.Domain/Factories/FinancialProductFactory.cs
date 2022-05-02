using Aliquota.Domain.Entities;
using Aliquota.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Factories
{
    class FinancialProductFactory
    {
        public FinancialProduct BuildNewFinancialProduct(string name, string lastName, string percentage)
        {
            Guid financialProductID = Guid.NewGuid();
            FullName _name = new FullName(name, lastName);
            ProductPercentage _percentage = new ProductPercentage((double.Parse(percentage)/100));
            FinancialProduct financialProduct = new FinancialProduct(financialProductID, _name, _percentage);
            return financialProduct;
        }
    }
}
