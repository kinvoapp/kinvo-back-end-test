using System;
using System.Globalization;
using Aliquota.Domain.Contracts.Repositories;
using Aliquota.Domain.Entities;
using Moq;

namespace Aliquota.Domain.Test.Mocks.Repositories
{
    public static class InvestmentRepositoryMockProvider
    {

        public static Investment SharedInvestment { get; set; } = GetStandardInvestment();
        public static Investment GetStandardInvestment()
        {
            var investment = new Investment()
            {
                InitialValue = 200.0,
                ApplicationDate = DateTimeOffset.Now.AddMinutes(-20),
                FinancialProduct = FinancialProductRepositoryMockProvider.SharedProduct,
                Portfolio = PortfolioRepositoryMockProvider.SharedPortfolio,
            };

            return investment;
        }

        public static Mock<IInvestmentRepository> GetNewMock()
        {
            var mock = new Mock<IInvestmentRepository>();

            mock.Setup(r => r.Add(It.IsAny<Investment>()));
            mock.Setup(r => r.GetInvestmentAsync(It.IsAny<Guid>())).ReturnsAsync(SharedInvestment);
            return mock;
        }
    }
}