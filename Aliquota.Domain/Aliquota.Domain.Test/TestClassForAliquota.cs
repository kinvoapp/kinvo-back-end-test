using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Aliquota.Domain.Services;

namespace Aliquota.Domain.Test
{
    public class TestClassForAliquota
    {
        [Fact]
        public void TestForMonthQuantity()
        {
            //Assert
            DateTime sample = new DateTime(2021, 08, 02);
            DateTime investmentDay = new DateTime(2020, 05, 01);
            int expectedResult = 15;
            //Act
            var result = AliquotaCalc.MonthQuantity(sample, investmentDay);
            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(4, 300, 64.65)]
        [InlineData(14, 1000, 979.93)]
        [InlineData(1, 10, 0.5)]
        [InlineData(38, 50, 269.27)]
        [InlineData(55, 1000, 13635.63)]
        public void TestForCalculateProfit(int amountOfMonths, double startedAmount, double expectedResult)
        {
            //Act
            var result = AliquotaCalc.CalculateProfit(amountOfMonths, startedAmount);
            //Assert
            Assert.Equal(expectedResult, result, 2);
        }
        [Theory]
        [InlineData(400, 90)]
        [InlineData(5000, 1125)]
        [InlineData(389, 87.52)]
        public void TestForProfitOneYear(double profit, double expectedResult)
        {
            //Act
            var result = AliquotaCalc.ProfitOneYear(profit);
            //Assert
            Assert.Equal(expectedResult, result,1);
        }
        [Theory]
        [InlineData(400, 74)]
        [InlineData(5000, 925)]
        [InlineData(389, 71.96)]
        public void TestForProfitOneToTwoYear(double profit, double expectedResult)
        {
            //Act
            var result = AliquotaCalc.ProfitOneToTwoYear(profit);
            //Assert
            Assert.Equal(expectedResult, result, 1);
        }

        [Theory]
        [InlineData(400, 60)]
        [InlineData(5000, 750)]
        [InlineData(389, 58.35)]
        public void TestForProfitTwoYear(double profit, double expectedResult)
        {
            //Act
            var result = AliquotaCalc.ProfitTwoYear(profit);
            //Assert
            Assert.Equal(expectedResult, result, 1);
        }

    }
}
