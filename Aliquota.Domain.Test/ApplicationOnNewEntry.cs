using System;
using Xunit;
using Aliquota.Domain;

namespace Aliquota.Domain.Test
{
    public class ApplicationOnNewEntry
    {
        [Fact]
        public void OnNewEntry_WhenSubmitting_ReturnsVoidAndSetsParameters()
        {
            var application = new Application();
            application.InvestedValue = 1000;
            application.MonthlyInterestRate = 4;
            application.ExpectedMonthlyPeriod = 12;

            application.OnNewEntry();

            var applyDateExpected = DateTime.Now.Date;
            Assert.Equal(applyDateExpected, application.ApplyDate.Date);

            var withdrawDateExpected = applyDateExpected.AddMonths(12).Date;
            Assert.Equal(withdrawDateExpected, application.WithdrawDate.Date);

            decimal profitValueExpected = 600;
            Assert.Equal(profitValueExpected, application.ProfitValue);

            decimal totalValueExpected = 1600;
            Assert.Equal(totalValueExpected, application.TotalValue);

            decimal withholdedValueExpected = 135;
            Assert.Equal(withholdedValueExpected, application.WithholdedValue);
        }
    }
}
