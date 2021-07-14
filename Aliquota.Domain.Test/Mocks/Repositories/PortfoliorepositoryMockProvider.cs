using System;
using System.Collections.Generic;
using Aliquota.Domain.Contracts.Repositories;
using Aliquota.Domain.Entities;
using Moq;

namespace Aliquota.Domain.Test.Mocks.Repositories
{
    public static class PortfolioRepositoryMockProvider
    {
        public static Portfolio SharedPortfolio { get; set; } = GetStandardPortfolio();

        public static Portfolio GetStandardPortfolio() 
        {
            var portfolio = new Portfolio()
            {
                Balance = 500.0,
                Investments = new List<Investment>(),
                OwnerId = Guid.Empty,
                Owner = new User("David Hilbert", "david.hilbert@email.com") {},
            };
            return portfolio;
        }

        public static Mock<IPortfolioRepository> GetNewMock()
        {
            var mock = new Mock<IPortfolioRepository>();

            mock.Setup(r => r.Add(It.IsAny<Portfolio>()));
            mock.Setup(r => r.GetPortfolioByOwnerIdAsync(SharedPortfolio.OwnerId)).ReturnsAsync(SharedPortfolio);
            return mock;
        }
    }
}