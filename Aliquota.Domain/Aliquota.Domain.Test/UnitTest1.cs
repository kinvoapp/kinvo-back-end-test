using Model.Infra.CrossCutting;
using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestRescueTaxOneOrLessYearsInvested()
        {
            Rescue r = new Rescue();
            DateTime InvestmentDayZero = new DateTime(2020, 07, 28);
            double result = r.rescue(12000, InvestmentDayZero);
            Assert.Equal(10538.532110091743, result);
        }

        [Fact]
        public void TestRescueTaxOneToTwoYearsInvested()
        {
            Rescue r = new Rescue();
            DateTime InvestmentDayZero = new DateTime(2019, 07, 28);
            double result = r.rescue(12000, InvestmentDayZero);
            Assert.Equal(10612.279270573175, result);
        }

        [Fact]
        public void TestRescueTaxMoreThanTwoYearsInvested()
        {
            Rescue r = new Rescue();
            DateTime InvestmentDayZero = new DateTime(2018, 07, 28);
            double result = r.rescue(12000, InvestmentDayZero);
            Assert.Equal(10474.97823612134, result);
        }
    }
}
