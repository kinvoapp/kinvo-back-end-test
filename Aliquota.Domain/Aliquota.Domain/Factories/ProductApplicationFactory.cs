using Aliquota.Domain.Entities;
using Aliquota.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Factories
{
    class ProductApplicationFactory
    {
        public ProductApplication BuildNewProductApplication(Guid clientID, Guid financialProductID, string amountMoney)
        {
            Guid productApplicationID = Guid.NewGuid();
            DateTime dateApplication = DateTime.Now;
            AmountMoney _amountMoney = new AmountMoney(double.Parse(amountMoney));
            ProductApplication productApplication = new ProductApplication(productApplicationID, clientID, financialProductID, dateApplication, _amountMoney);
            return productApplication;
        }
    }
}
