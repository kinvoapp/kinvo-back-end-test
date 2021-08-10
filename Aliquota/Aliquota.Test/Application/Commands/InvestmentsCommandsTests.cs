using System;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Application.Exceptions;
using Aliquota.Application.Features.FinancialProducts.Commands;
using Aliquota.Application.Features.Investments.Commands;
using Aliquota.Domain.Enums;
using Aliquota.Test.Application.Base;
using Xunit;
using static Aliquota.Test.Application.Base.TestingBaseFixture;

namespace Aliquota.Test.Application.Commands
{
    [Collection("CollectionFixture")]
    public class InvestmentsCommandsTests
    {
        private readonly TestingBaseFixture _fixture;

        public InvestmentsCommandsTests(TestingBaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ShouldRequireMinimumFields()
        {
            //arrange
            var command = new CreateInvestmentCommand();

            //act
            var errors = await Assert.ThrowsAsync<ValidationException>(async () => await SendAsync(command));

            //assert
            Assert.IsType<ValidationException>(errors);
        }

        [Fact]
        public async Task StartDateCannotBeNull()
        {
            //arrange
            var createFinancialProductCommand = new CreateFinancialProductCommand()
            {
                Name = "Testing start date investment validation",
                Deadline = Deadline.AtLeastOneYear,
                Profitability = Profitability.Medium,
                MonthlyIncome = 0.15M,
                MinimalInvestedAmount = 250
            };

            var command = new CreateInvestmentCommand()
            {
                Amount = 500,
                FinancialProductId = await SendAsync(createFinancialProductCommand),
            };

            //act
            var errors = await Assert.ThrowsAsync<ValidationException>(async () => await SendAsync(command));

            //assert
            Assert.IsType<ValidationException>(errors);
            Assert.Contains("Invalid start date", errors.Errors.First());
        }

        [Fact]
        public async Task ShouldRequireFinancialProductId()
        {
            //arrange
            var command = new CreateInvestmentCommand()
            {
                Amount = 500,
                Start = DateTime.Now
            };

            //act
            var errors = await Assert.ThrowsAsync<ValidationException>(async () => await SendAsync(command));

            //assert
            Assert.IsType<ValidationException>(errors);
            Assert.Contains("FinancialProductId cannot be empty", errors.Errors.First());
        }

        [Fact]
        public async Task ShouldRequireAmountToBeGreaterThanMinimalInvestedAmount()
        {
            //arrange
            var createFinancialProductCommand = new CreateFinancialProductCommand()
            {
                Name = "Testing investment minimal invested amount validation",
                Deadline = Deadline.AtLeastOneYear,
                Profitability = Profitability.Medium,
                MonthlyIncome = 0.15M,
                MinimalInvestedAmount = 750
            };

            var command = new CreateInvestmentCommand()
            {
                Amount = 500,
                FinancialProductId = await SendAsync(createFinancialProductCommand),
            };

            //act
            var errors = await Assert.ThrowsAsync<ValidationException>(async () => await SendAsync(command));

            //assert
            Assert.IsType<ValidationException>(errors);
            Assert.Contains("Amount should be Equal or greater than Minimal Invested Amount from Financial Product.", errors.Errors.First());
        }

        [Fact]
        public async Task ShouldCreateWithdrawAndReturnIt()
        {
            var startDate = DateTime.Now.AddDays(-364);

            var createFinancialProductCommand = new CreateFinancialProductCommand()
            {
                Name = "Testing withdraw creation",
                Deadline = Deadline.AtLeastOneYear,
                Profitability = Profitability.Medium,
                MonthlyIncome = 0.15M,
                MinimalInvestedAmount = 750
            };

            var createInvestmentCommand = new CreateInvestmentCommand()
            {
                Amount = 2000,
                Start = startDate,
                FinancialProductId = await SendAsync(createFinancialProductCommand)
            };

            var command = new CreateWithdrawInvestmentCommand()
            {
                Id = await SendAsync(createInvestmentCommand),
                WithdrawDate = DateTime.Now
            };

            var withdraw = await SendAsync(command);

            Assert.NotNull(withdraw);
        }

        [Fact]
        public async Task ShouldCreateValidWithdrawAndReturnIt()
        {
            var startDate = DateTime.Now.AddDays(-365);
            var now = DateTime.Now;
            var investedTime = (decimal) (now - startDate).TotalDays;
            decimal taxPercentage;

            if (investedTime <= Year.ONEYEAR)
                taxPercentage = 0.225M;
            else if (investedTime > Year.ONEYEAR && investedTime <= Year.TWOYEARS)
                taxPercentage = 0.185M;
            else
                taxPercentage = 0.15M;

            var createFinancialProductCommand = new CreateFinancialProductCommand()
            {
                Name = "Testing valid withdraw creation",
                Deadline = Deadline.AtLeastOneYear,
                Profitability = Profitability.Medium,
                MonthlyIncome = 0.15M,
                MinimalInvestedAmount = 750
            };

            var createInvestmentCommand = new CreateInvestmentCommand()
            {
                Amount = 2000,
                Start = startDate,
                FinancialProductId = await SendAsync(createFinancialProductCommand)
            };

            var command = new CreateWithdrawInvestmentCommand()
            {
                Id = await SendAsync(createInvestmentCommand),
                WithdrawDate = now
            };

            var withdraw = await SendAsync(command);

            Assert.Equal(createInvestmentCommand.Amount, withdraw.Amount);
            Assert.Equal(investedTime, withdraw.InvestedTime);
            Assert.Equal(taxPercentage, withdraw.TaxPercentage);
        }
    }
}