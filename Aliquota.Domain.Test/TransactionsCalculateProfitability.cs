using System;
using Xunit;
using Aliquota.Domain;

namespace Aliquota.Domain.Test
{
    public class TransactionsCalculateProfitability
    {
        [Theory]
        [InlineData(1, 2f, 1.02)]
        [InlineData(12, 4f, 1.60)]
        [InlineData(16, 5f, 2.18)]
        public void CalculateProfitability_InMonths_ReturnsProfitabilityInMonths(int expectedMonthlyPeriod, double monthlyInterestRate, decimal expected)
        {
            decimal profitability = Transactions.CalculateProfitability(expectedMonthlyPeriod, monthlyInterestRate);

            Assert.Equal(expected, profitability);
        }
    }
}
