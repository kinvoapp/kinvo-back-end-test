using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class AccountApply
    {        
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Apply_ValueLessOrEqualToZero_FailToApply(float value)
        {
            var account = new Account();

            var application = new Application(account, value, DateTime.Now);

            bool fail = !account.Apply(application);

            Assert.True(fail);
        }
    }
}
