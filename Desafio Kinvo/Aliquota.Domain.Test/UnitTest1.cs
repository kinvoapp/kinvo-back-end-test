using System;
using Xunit;
using Aliquota.Domain.Models;
using Aliquota.Domain.Repository;


namespace Aliquota.Domain.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            RDefault rDefault = new RDefault();

            Investment investment = new Investment();

            string test = rDefault.ValInfo(investment);

            Assert.Equal("Investimento Inválido!", test);
        }


        [Fact]
        public void Test2()
        {
            RDefault rDefault = new RDefault();

            Investment investment = new Investment
            {
                nickname = "",
                period = 3,
                amountBegin = (decimal)350.0
            };


            string test = rDefault.ValInfo(investment);

            Assert.Equal("Investimento Inválido!", test);
        }
        [Fact]
        public void Test3()
        {
            RDefault rDefault = new RDefault();

            Investment investment = new Investment
            {
                nickname = "tiago",
                period = -3,
                amountBegin = (decimal)350.0
            };


            string test = rDefault.ValInfo(investment);

            Assert.Equal("Investimento Inválido!", test);
        }

        [Fact]
        public void Test4()
        {
            RDefault rDefault = new RDefault();

            Investment investment = new Investment
            {
                nickname = "tiago",
                period = 3,
                amountBegin = (decimal)-350.0
            };


            string test = rDefault.ValInfo(investment);

            Assert.Equal("Investimento Inválido!", test);
        }

        [Fact]
        public void Test5()
        {
            RDefault rDefault = new RDefault();

            Investment investment = new Investment {
                nickname = "tiago",
                period = 3,
                amountBegin = (decimal) 350.0
            };


            string test = rDefault.ValInfo(investment);

            Assert.Equal("Novo investimento adcicionado!", test);
        }
    }
}
