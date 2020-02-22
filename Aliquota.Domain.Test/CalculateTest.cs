using Aliquota.Domain.Entities;
using Aliquota.Domain.Entities.Exceptions;
using System;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class CalculateTest
    {

        [Theory]
        [InlineData (-1)]
        [InlineData (0)]
        public void InitialAmountLesserOrEqualThanZero(double value)
        {
            Assert.Throws<CalculateException>(()=>new Investment(value));
        }

        [Fact]
        public void FinalDateLesserThanInitialDate()
        {
            Investment investment = new Investment(1000);
            Assert.Throws<CalculateException>(() => new Invoice(DateTime.Parse("21/10/2020"), DateTime.Parse("15/01/2019"), investment));
        }
    }
}