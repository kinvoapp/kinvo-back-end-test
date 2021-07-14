using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aliquota.Domain.Commands;
using Aliquota.Domain.Contracts.Repositories;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Exceptions;
using Aliquota.Domain.Handlers;
using Aliquota.Domain.Services;
using Aliquota.Domain.Test.Mocks;
using Aliquota.Domain.Test.Mocks.Repositories;
using Moq;
using Xunit;

namespace Aliquota.Domain.Test.Handlers
{
    public class InvestmentHandlerTests
    {
        private readonly Mock<IPortfolioRepository> portfolioRepositoryMock;
        private readonly Mock<IFinancialProductRepository> financialProductRepositoryMock;
        private readonly Mock<IInvestmentRepository> investmentRepositoryMock;
        private readonly InvestmentHandler investmentHandler;

        public InvestmentHandlerTests()
        {
            portfolioRepositoryMock = PortfolioRepositoryMockProvider.GetNewMock();
            financialProductRepositoryMock = FinancialProductRepositoryMockProvider.GetNewMock();
            investmentRepositoryMock = InvestmentRepositoryMockProvider.GetNewMock();

            investmentHandler = new InvestmentHandler(portfolioRepositoryMock.Object,
                                                      financialProductRepositoryMock.Object,
                                                      investmentRepositoryMock.Object,
                                                      new InvestmentEvaluationService());
        }

        [Fact]
        public async Task HandleAsync_CreateInvestmentCommand_ShouldThrowWhenValueIsLessThanZero()
        {
            var portfolio = PortfolioRepositoryMockProvider.GetStandardPortfolio();

            var command = new CreateInvestmentCommand
            {
                Value = -20.0,
            };

            await Assert.ThrowsAsync<HandlerException>(async () =>
            {
                await investmentHandler.HandleAsync(command, portfolio.OwnerId);
            });
        }

        [Fact]
        public async Task HandleAsync_CreateInvestmentCommand_ShouldThrowWhenValueIsGreaterThanBalance()
        {
            var portfolio = PortfolioRepositoryMockProvider.GetStandardPortfolio();
            var command = new CreateInvestmentCommand
            {
                Value = portfolio.Balance * 20,
            };

            await Assert.ThrowsAsync<HandlerException>(async () =>
            {
                await investmentHandler.HandleAsync(command, portfolio.OwnerId);
            });
        }

        [Fact]
        public async Task HandleAsync_CreateInvestmentCommand_ShouldCreateInvestmentAndDiscountBalanceProperly()
        {
            var portfolio = PortfolioRepositoryMockProvider.SharedPortfolio;
            var product = FinancialProductRepositoryMockProvider.GetStandardFinancialProduct();
            var command = new CreateInvestmentCommand
            {
                Value = portfolio.Balance - 20,
                ProductId = product.Id,
            };

            Investment generatedInvestment = null;
            generatedInvestment = await investmentHandler.HandleAsync(command, portfolio.OwnerId);

            Assert.NotNull(generatedInvestment);
            Assert.Equal(20, portfolio.Balance);
            Assert.Equal(command.Value, generatedInvestment.InitialValue);
        }

        [Fact]
        public async Task HandleAsync_RedemptInvestmentCommand_ShouldUpdateInvestmentAndBalanceProperly()
        {
            var portfolio = PortfolioRepositoryMockProvider.SharedPortfolio;
            var initialBalance = portfolio.Balance;
            InvestmentRepositoryMockProvider.SharedInvestment.ApplicationDate = DateTimeOffset.Now.AddMinutes(-5);
            InvestmentRepositoryMockProvider.SharedInvestment.InitialValue = 200.0;
            FinancialProductRepositoryMockProvider.SharedProduct.EvaluatorsSpec = new List<InvestmentEvaluatorSpec>()
            {
                new InvestmentEvaluatorSpec()
                {
                    EvaluatorType = InvestmentEvaluatorTypes.ConstantMultiplier,
                    Config = new ConstantMultiplierEvaluatorParams
                    {
                        Multiplier = 3,
                        PeriodMinutes = 1,
                    }
                }
            };

            var command = new RedemptInvestmentCommand
            {
                InvestmentId = Guid.NewGuid(),
            };

            Investment redemptedInvestment = null;
            redemptedInvestment = await investmentHandler.HandleAsync(command);

            Assert.NotNull(redemptedInvestment.RedemptionDate);
            Assert.True(initialBalance < portfolio.Balance);
        }

        [Fact]
        public async Task HandleAsync_RedemptInvestmentCommand_ShouldThrownWhenInvestmentAlreadyRedempted()
        {
            var portfolio = PortfolioRepositoryMockProvider.SharedPortfolio;
            var initialBalance = portfolio.Balance;
            InvestmentRepositoryMockProvider.SharedInvestment.ApplicationDate = DateTimeOffset.Now.AddMinutes(-5);
            InvestmentRepositoryMockProvider.SharedInvestment.RedemptionDate = DateTimeOffset.Now.AddMinutes(-2);
            InvestmentRepositoryMockProvider.SharedInvestment.InitialValue = 200.0;
            FinancialProductRepositoryMockProvider.SharedProduct.EvaluatorsSpec = new List<InvestmentEvaluatorSpec>()
            {
                new InvestmentEvaluatorSpec()
                {
                    EvaluatorType = InvestmentEvaluatorTypes.ConstantMultiplier,
                    Config = new ConstantMultiplierEvaluatorParams
                    {
                        Multiplier = 3,
                        PeriodMinutes = 1,
                    }
                }
            };

            var command = new RedemptInvestmentCommand
            {
                InvestmentId = Guid.NewGuid(),
            };

            Investment redemptedInvestment = null;
            await Assert.ThrowsAsync<HandlerException>(async () =>
            {
                redemptedInvestment = await investmentHandler.HandleAsync(command);
            });
        }
    }
}