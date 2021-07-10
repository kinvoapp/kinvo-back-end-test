using Aliquota.Domain.Contracts.Repositories;
using Aliquota.Domain.Entities;
using Moq;

namespace Aliquota.Domain.Test.Mocks.Repositories
{
    public static class PortfolioRepositoryMockProvider
    {
        public static Mock<IPortfolioRepository> GetNewMock()
        {
            var mock = new Mock<IPortfolioRepository>();

            mock.Setup(r => r.Add(It.IsAny<Portfolio>()));
            return mock;
        }
    }
}