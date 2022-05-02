using Aliquota.Domain.Entities;
using Aliquota.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aliquota.Domain.Test.Entities
{
    public class TestProductApplication
    {
        [Fact]
        public void TestInitWhenValidArgsThenBuildProductApplication()
        {
            //Arrange
            Guid productApplicationID = Guid.NewGuid();
            Guid clientID = Guid.NewGuid();
            Guid financialProductID = Guid.NewGuid();
            DateTime dateApplication = DateTime.Now;
            string amountMoneyValue = "10000.00";
            AmountMoney _amountMoney = new AmountMoney(double.Parse(amountMoneyValue));

            //Action
            ProductApplication productApplication = new ProductApplication(productApplicationID, clientID, financialProductID, dateApplication, _amountMoney);

            //Assert
            Assert.IsType<ProductApplication>(productApplication);
        }
    }
}
