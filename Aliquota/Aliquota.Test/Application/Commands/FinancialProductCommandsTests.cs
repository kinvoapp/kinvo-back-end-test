using System;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Application.Exceptions;
using Aliquota.Application.Features.FinancialProducts.Commands;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Enums;
using Aliquota.Test.Application.Base;
using Xunit;
using static Aliquota.Test.Application.Base.TestingBaseFixture;

namespace Aliquota.Test.Application.Commands
{
    [Collection("CollectionFixture")]
    public class FinancialProductCommandsTests
    {
        private readonly TestingBaseFixture _fixture;

        public FinancialProductCommandsTests(TestingBaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ShouldRequireMinimumFields()
        {
            //arrange
            var command = new CreateFinancialProductCommand();

            //assert
            var errors = await Assert.ThrowsAsync<ValidationException>(async () => /*act*/ await SendAsync(command));

            Assert.IsType<ValidationException>(errors);
        }

        [Fact]
        public async Task ShouldCreateFinancialProductCommand()
        {
            //arrange
            var command = new CreateFinancialProductCommand
            {
                Deadline = Deadline.AtLeastOneYear,
                Name = "Testing create command",
                Profitability = Profitability.High,
                MonthlyIncome = 0.225M,
                MinimalInvestedAmount = 500
            };

            //act
            var id = await SendAsync(command);
            var result = await FindAsync<FinancialProduct>(id);

            //assert
            Assert.Equal(id, result?.Id);
        }

        [Fact]
        public async Task ShouldDeleteFinancialProductCommand()
        {
            //arrange
            var command = new CreateFinancialProductCommand
            {
                Deadline = Deadline.AtLeastOneYear,
                Name = "Testing delete command",
                Profitability = Profitability.High,
                MonthlyIncome = 0.225M,
                MinimalInvestedAmount = 500
            };

            var financialProductId = await SendAsync(command);

            //act
            await SendAsync(new DeleteFinancialProductCommand() {Id = financialProductId});

            var result = await FindAsync<FinancialProduct>(financialProductId);

            //assert
            Assert.Null(result);
        }

        [Fact]
        public async Task ShouldRequireUniqueName()
        {
            //arrange
            var command = new CreateFinancialProductCommand
            {
                Deadline = Deadline.AtLeastOneYear,
                Name = "Testing unique name",
                Profitability = Profitability.High,
                MonthlyIncome = 0.225M,
                MinimalInvestedAmount = 500
            };

            await SendAsync(command);

            //act
            var errors = await Assert.ThrowsAsync<ValidationException>(async () => await SendAsync(command));

            Assert.Contains("Name should be unique", errors.Errors.First());
        }

        [Fact]
        public async Task MinimalInvestedAmountShouldBeNegative()
        {
            //arrange
            var command = new CreateFinancialProductCommand
            {
                Deadline = Deadline.AtLeastOneYear,
                Name = "Testing less than zero",
                Profitability = Profitability.High,
                MonthlyIncome = 0.225M,
                MinimalInvestedAmount = -500
            };

            //act
            var errors = await Assert.ThrowsAsync<ValidationException>(async () => await SendAsync(command));

            Assert.Contains("Minimal Invested Amount cannot be negative or zero.", errors.Errors.First());
        }

        [Fact]
        public async Task MinimalInvestedAmountShouldNotBeEqualToZero()
        {
            //arrange
            var command = new CreateFinancialProductCommand
            {
                Deadline = Deadline.AtLeastOneYear,
                Name = "Testing equal zero",
                Profitability = Profitability.High,
                MonthlyIncome = 0.225M,
                MinimalInvestedAmount = 0
            };

            //act
            var errors = await Assert.ThrowsAsync<ValidationException>(async () => await SendAsync(command));

            Assert.Contains("Minimal Invested Amount cannot be negative or zero.", errors.Errors.First());
        }

        [Fact]
        public async Task ProfitabilityShouldNotBeOutOfRange()
        {
            //arrange
            var command = new CreateFinancialProductCommand
            {
                Deadline = Deadline.AtLeastOneYear,
                Name = "Testing out of range profitability",
                Profitability = Enum.GetValues(typeof(Profitability)).Cast<Profitability>().Last() + 1,
                MonthlyIncome = 0.225M,
                MinimalInvestedAmount = 500
            };

            //act
            var errors = await Assert.ThrowsAsync<ValidationException>(async () => await SendAsync(command));

            Assert.Contains("Profitability is out of range.", errors.Errors.First());
        }

        [Fact]
        public async Task DeadlineShouldNotBeOutOfRange()
        {
            //arrange
            var command = new CreateFinancialProductCommand
            {
                Deadline = Enum.GetValues(typeof(Deadline)).Cast<Deadline>().Last() + 1,
                Name = "Testing out of range deadline",
                Profitability = Profitability.Medium,
                MonthlyIncome = 0.225M,
                MinimalInvestedAmount = 500
            };

            //act
            var errors = await Assert.ThrowsAsync<ValidationException>(async () => await SendAsync(command));

            Assert.Contains("Deadline is out of range.", errors.Errors.First());
        }

        [Fact]
        public async Task CannotDeleteWithoutId()
        {
            //arrange
            var command = new DeleteFinancialProductCommand();

            //act
            var errors = await Assert.ThrowsAsync<ValidationException>(async () => await SendAsync(command));

            //assert
            Assert.IsType<ValidationException>(errors);
            Assert.Contains("Id cannot be empty.", errors.Errors.First());
        }
    }
}