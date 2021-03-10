using System;
using Xunit;
using Aliquota.Domain;

namespace Aliquota.Domain.Test
{
    public class TransactionsCalculateIncomeTax
    {
        [Theory]
        //0 < x <= 1
        [InlineData(float.Epsilon, 22.5f / 100f)]
        [InlineData(1, 22.5f / 100f)]
        //1 < x <= 2
        [InlineData(1 + 0.00001, 18.5f / 100f)]
        [InlineData(2, 18.5f / 100f)]
        //0 < 2
        [InlineData(2 + 0.00001, 15f / 100f)]
        [InlineData(3, 15f / 100f)]
        public void CalculateIncomeTax_WhenWithdrawing_ReturnsIncomeTax(float yearsFromApplication, decimal expected)
        {
            decimal incomeTax = Transactions.CalculateIncomeTax(yearsFromApplication);

            Assert.Equal(expected, incomeTax);
        }
    }
}
