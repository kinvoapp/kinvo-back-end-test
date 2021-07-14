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
                ApplicationDate = new DateTimeOffset(2019, 10, 6, 10, 0, 0, 0, new GregorianCalendar(), new TimeSpan(0)),
            };

            return investment;
        }

        public static Mock<IInvestmentRepository> GetNewMock()
        {
            var mock = new Mock<IInvestmentRepository>();

            mock.Setup(r => r.Add(It.IsAny<Investment>()));
            mock.Setup(r => r.GetInvestmentAsync(It.IsAny<Guid>())).ReturnsAsync(GetStandardInvestment());
            return mock;
        }
    }
}