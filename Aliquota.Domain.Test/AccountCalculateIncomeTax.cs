using System;
using Xunit;
using Aliquota.Domain;

namespace Aliquota.Domain.Test
{
    public class AccountCalculateIncomeTax
    {
        [Theory]
        //0 < x <= 1
        [InlineData(float.Epsilon, 22.5)]
        [InlineData(1, 22.5)]
        //1 < x <= 2
        [InlineData(1 + 0.00001, 18.5)]
        [InlineData(2, 18.5)]
        //0 < 2
        [InlineData(2 + 0.00001, 15)]
        [InlineData(3, 15)]
        public void CalculateIncomeTax_WhenWithdrawing_ReturnsIncomeTax(float yearsFromApplication, float expected)
        {
            var account = new Account();

            float incomeTax = account.CalculateIncomeTax(yearsFromApplication);

            Assert.Equal(expected, incomeTax);
        }
    }
}
