using System.Threading.Tasks;
using Aliquota.Domain.Commands;
using Aliquota.Domain.Contracts.Repositories;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Exceptions;
using Aliquota.Domain.Handlers;
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
                                                      investmentRepositoryMock.Object);
        }

        [Fact]
        public void HandleAsync_ShouldThrowWhenValueIsLessThanZero()
        {
            var portfolio = PortfolioRepositoryMockProvider.GetStandardPortfolio();
            
            var command = new CreateInvestmentCommand
            {
                Value = -20.0,
            };

            Assert.ThrowsAsync<HandlerException>(async () =>
            {
                await investmentHandler.HandleAsync(command, portfolio.OwnerId);
            });
        }

        [Fact]
        public void HandleAsync_ShouldThrowWhenValueIsGreaterThanBalance()
        {
            var portfolio = PortfolioRepositoryMockProvider.GetStandardPortfolio();
            var command = new CreateInvestmentCommand
            {
                Value = portfolio.Balance * 20,
            };

            Assert.ThrowsAsync<HandlerException>(async () =>
            {
                await investmentHandler.HandleAsync(command, portfolio.OwnerId);
            });
        }

        [Fact]
        public async Task HandleAsync_ShouldCreateInvestmentAndDiscountBalanceProperly()
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

    }
}