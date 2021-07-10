using Aliquota.Domain.Contracts.Repositories;
using Aliquota.Domain.Entities;
using Moq;

namespace Aliquota.Domain.Test.Mocks.Repositories
{
    public static class UserRepositoryMockProvider
    {
        public static Mock<IUserRepository> GetNewMock()
        {
            var mock = new Mock<IUserRepository>();

            mock.Setup(r => r.Add(It.IsAny<User>()));
            return mock;
        }
    }
}