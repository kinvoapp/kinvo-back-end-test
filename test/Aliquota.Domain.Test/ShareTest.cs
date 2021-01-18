using System;
using Aliquota.Domain.Entity;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class ShareTest
    {
        [Fact]
        public void BetweenOneAndTwoYearsFactor()
        {
            // Arrange
            var share = new Share()
            {
                Value = 1000,
                ApplicationDate = new DateTime(2018, 1, 1),
                WithdrawDate = new DateTime(2020, 1, 1)
            };
            var expectedValue = 815;
            // Assert
            Assert.Equal(share.AfterTaxValue, expectedValue);
        }

        [Fact]
        public void OneYearFactor()
        {
            // Arrange
            var share = new Share()
            {
                Value = 1000,
                ApplicationDate = new DateTime(2019, 1, 1),
                WithdrawDate = new DateTime(2020, 1, 1)
            };
            var expectedValue = 775;
            // Assert
            Assert.Equal(share.AfterTaxValue, expectedValue);

        }

        [Fact]
        public void PlusTwoYearsFactor()
        {
            // Arrange
            var share = new Share()
            {
                Value = 1000,
                ApplicationDate = new DateTime(2017, 1, 1),
                WithdrawDate = new DateTime(2020, 1, 1)
            };
            var expectedValue = 850;
            // Assert
            Assert.Equal(share.AfterTaxValue, expectedValue);

        }

    }
}
