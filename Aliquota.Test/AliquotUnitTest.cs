using Aliquota.Domain;
using Aliquota.Domain.Exceptions;
using Aliquota.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace Aliquota.Test
{
    public class AliquotUnitTest
    {
        [Fact]
        public void RejectZeroProfitInvestment()
        {
            Assert.Throws<BusinessException>(() =>
            {
                Aliquot.AddProfit(1,0);
            });
        }

        [Fact]
        public void RejectNegativeProfitInvestment()
        {
            Assert.Throws<BusinessException>(() =>
            {
                Aliquot.AddProfit(1,-1);
            });
        }

        [Fact]
        public void RejectInvalidProfitInvestment()
        {
            Assert.Throws<BusinessException>(() =>
            {
                Aliquot.AddProfit(0, 1000);
            });
        }

        [Fact]
        public void RejectZeroInvestment()
        {
            Assert.Throws<BusinessException>(() =>
            {
                Aliquot.Apply(0);
            });
        }

        [Fact]
        public void RejectNegativeInvestment()
        {
            Assert.Throws<BusinessException>(() =>
            {
                Aliquot.Apply(-1);
            });
        }

        [Fact]
        public void ApplyingInvestment()
        {
            var options = new DbContextOptionsBuilder<AliquotContext>();
            options.UseInMemoryDatabase("aliquot_test");
            var context = new AliquotContext(options.Options);

            Aliquot.context = context;
            
           var investiment = Aliquot.Apply(100);
           Assert.True(investiment.ID != 0);

        }

        [Fact]
        public void AddProfitInvestment()
        {
            var options = new DbContextOptionsBuilder<AliquotContext>();
            options.UseInMemoryDatabase("aliquot_test");
            var context = new AliquotContext(options.Options);

            Aliquot.context = context;
            var span = new TimeSpan(180, 0, 0, 0);
            var application = DateTime.Now.Subtract(span);
            var investiment = Aliquot.Apply(1000, application);
            
            Aliquot.AddProfit(investiment.ID, 30M);

            investiment = context.Investments.Find(investiment.ID);
            Assert.Equal(30M, investiment.Profit, 2);

        }

        [Fact]
        public void RescueUpTo1YearInvestment()
        {
            var options = new DbContextOptionsBuilder<AliquotContext>();
            options.UseInMemoryDatabase("aliquot_test");
            var context = new AliquotContext(options.Options);

            Aliquot.context = context;
            var span = new TimeSpan(180, 0, 0, 0);
            var application = DateTime.Now.Subtract(span);
            var investiment = new Aliquota.Domain.Entities.Investment()
            {
                Application = application,
                Value = 100,
                Profit = 30
            };
            context.Investments.Add(investiment);
            context.SaveChanges();
            var val = Aliquot.Rescue(investiment.ID);
            Assert.Equal(123.25M, val, 2);

        }

        [Fact]
        public void RescueLessThan2YearsInvestment()
        {
            var options = new DbContextOptionsBuilder<AliquotContext>();
            options.UseInMemoryDatabase("aliquot_test");
            var context = new AliquotContext(options.Options);

            Aliquot.context = context;
            var span = new TimeSpan(400, 0, 0, 0);
            var application = DateTime.Now.Subtract(span);
            var investiment = new Aliquota.Domain.Entities.Investment()
            {
                Application = application,
                Value = 100,
                Profit = 30
            };
            context.Investments.Add(investiment);
            context.SaveChanges();
            var val = Aliquot.Rescue(investiment.ID);
            Assert.Equal(124.45M, val, 2);
        }

        [Fact]
        public void RescueAbove2YearsInvestment()
        {
            var options = new DbContextOptionsBuilder<AliquotContext>();
            options.UseInMemoryDatabase("aliquot_test");
            var context = new AliquotContext(options.Options);

            Aliquot.context = context;
            var span = new TimeSpan(800, 0, 0, 0);
            var application = DateTime.Now.Subtract(span);
            var investiment = new Aliquota.Domain.Entities.Investment()
            {
                Application = application,
                Value = 100,
                Profit = 30
            };
            context.Investments.Add(investiment);
            context.SaveChanges();
            var val = Aliquot.Rescue(investiment.ID);
            Assert.Equal(125.50M, val, 2);

        }

        [Fact]
        public void RejectRescueInvestment()
        {
            Assert.Throws<BusinessException>(() =>
            {
                Aliquot.Rescue(1000);
            });
        }

        [Fact]
        public void RejectRescueInvestmentInvalidDate()
        {
            Assert.Throws<BusinessException>(() =>
            {
                var options = new DbContextOptionsBuilder<AliquotContext>();
                options.UseInMemoryDatabase("aliquot_test");
                var context = new AliquotContext(options.Options);

                Aliquot.context = context;

                var investiment = Aliquot.Apply(1000, new DateTime(2021, 06, 30));
                var value = Aliquot.Rescue(investiment.ID);
            });
        }
    }
}
