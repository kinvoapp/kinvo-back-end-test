using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class AccountWithdraw
    {
        [Fact]
        public void Withdraw_UpToOneYearFromApplication_ReturnsApplication()
        {
            var account = new Account();

            Application application = account.Withdraw();

            Assert.NotNull(application); //fix
        }

        [Fact]
        public void Withdraw_OneYearToTwoYearsFromApplication_ReturnsApplication()
        {

        }

        [Fact]
        public void Withdraw_AboveTwoYearsFromApplication_ReturnsApplication()
        {

        }
    }
}
