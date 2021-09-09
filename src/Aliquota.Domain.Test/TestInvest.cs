using Aliquota.Business.Implementation;
using Aliquota.Business.Interfaces;
using Aliquota.Domain.Entitys;
using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class TestInvest
    {

        private const double IMP1 = 0.225;
        private const double IMP2 = 0.185;
        private const double IMP3 = 0.15;

        private IInvestRepository inv;

        [Fact]
        public void ValueRetention()
        {
            var invest = new Invest
            {
                AppDate = new DateTime().AddYears(2019),
                InvestedValue = 1000000

            };

            var expected = IMP2;

            var investManager = new InvestManager(inv);

            var result = investManager.ValueRetention(invest.AppDate);

            Assert.Equal(expected, result);


        }

        [Fact]
        public void ValideteValue()
        {
            var invest = new Invest
            {
                AppDate = new DateTime().AddYears(2019),
                InvestedValue = 1000000

            };
            var expected = true;

            var investManager = new InvestManager(inv);

            var result = investManager.ValidateValue(invest.InvestedValue);

            Assert.Equal(expected, result);
        }
    }
}
