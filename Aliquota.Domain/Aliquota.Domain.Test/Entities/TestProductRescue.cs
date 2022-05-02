using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aliquota.Domain.Test.Entities
{
    public class TestProductRescue
    {
        [Fact]
        public void TestInitWhenValidArgsThenBuildProductRescue()
        {
            //Arrange
            Guid productApplicationID = Guid.NewGuid();
            DateTime dateRescue = DateTime.Now;
            
            //Action
            ProductRescue productRescue = new ProductRescue(productApplicationID, dateRescue);

            //Assert
            Assert.IsType<ProductRescue>(productRescue);
        }
    }
}
