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
    public class TestFinancialProduct
    {
        [Fact]
        public void TestInitWhenValidArgsThenBuildFinancialProduct()
        {
            //Arrange
            Guid financialProductID = Guid.NewGuid();
            string nameValue = "Fundo";
            string lastNameValue = "Imobiliario";
            FullName _name = new FullName(nameValue, lastNameValue);
            string percentageValue = "18.34";
            ProductPercentage _percentage = new ProductPercentage((double.Parse(percentageValue) / 100));

            //Action
            FinancialProduct financialProduct = new FinancialProduct(financialProductID, _name, _percentage);

            //Assert
            Assert.IsType<FinancialProduct>(financialProduct);
        }
    }
}
