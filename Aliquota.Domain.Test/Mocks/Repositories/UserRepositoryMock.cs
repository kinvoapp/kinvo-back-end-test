using System.Threading.Tasks;
using Aliquota.Domain.Contracts.Repositories;
using Aliquota.Domain.Entities;
using Moq;

namespace Aliquota.Domain.Test.Mocks.Repositories
{
    public static class UserRepositoryMockProvider
    {
        public static User GetAlreadyRegisteredUserEmail()
        {
            var user = new User("mandelbrot@email.com", "Benoit Mandelbrot");
            user.SetPassword("HaveSeenThisBefore123");
            return user;
        }

        public static Mock<IUserRepository> GetNewMock()
        {
            var mock = new Mock<IUserRepository>();

            mock.Setup(r => r.Add(It.IsAny<User>()));
            mock.Setup(r => r.GetUserByEmailAsync(GetAlreadyRegisteredUserEmail().Email)).Returns(Task.FromResult(GetAlreadyRegisteredUserEmail()));
            
            return mock;
        }
    }
}