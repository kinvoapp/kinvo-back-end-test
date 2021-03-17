using Aliquota.Service.BusinessLogicServices;
using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class ValidacaoData
    {
        [Fact]
        public void TestDtApplicationIsSmallerThanDtRescue()
        {
            Assert.True(new RescueApplicationService().ValidateThatDtRescueSmallerThanDtApplication(DateTime.Now.AddDays(-3), DateTime.Now));
        }

    }
}
