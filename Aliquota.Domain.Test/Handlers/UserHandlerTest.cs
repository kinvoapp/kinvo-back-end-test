using System.Threading.Tasks;
using Aliquota.Domain.Commands;
using Aliquota.Domain.Contracts.Repositories;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Handlers;
using Aliquota.Domain.Test.Mocks.Repositories;
using Moq;
using Xunit;

namespace Aliquota.Domain.Test.Handlers {
    public class UserHandlerTests {
        private readonly UserHandler userHandler;
        private readonly Mock<IUserRepository> userRepositoryMock;
        private readonly Mock<IPortfolioRepository> portfolioRepositoryMock;

        public UserHandlerTests() {
            userRepositoryMock = UserRepositoryMockProvider.GetNewMock();
            portfolioRepositoryMock = PortfolioRepositoryMockProvider.GetNewMock();

            userHandler = new UserHandler(
                userRepositoryMock.Object,
                portfolioRepositoryMock.Object);
        }

        [Fact]
        public void Handle_CreateUserCommand_ShouldCallRepositories() {
            var command = new CreateUserCommand {
                Email = "alan.turing@email.com",
                FullName = "Alan Turing",
                Password = "EnigmaStriker123",
            };

            userHandler.Handle(command);

            userRepositoryMock.Verify(m => m.Add(It.IsAny<User>()), Times.Once());
            portfolioRepositoryMock.Verify(m => m.Add(It.IsAny<Portfolio>()), Times.Once());
        }

        [Fact]
        public void Handle_CreateUserCommand_ShouldCreateUserCorrectly() {
            var command = new CreateUserCommand {
                Email = "alan.turing@email.com",
                FullName = "Alan Turing",
                Password = "EnigmaStriker123",
            };

            var user = userHandler.Handle(command);

            Assert.Equal(user.Email, command.Email);
            Assert.Equal(user.FullName, command.FullName);
            Assert.True(user.VerifyPassword(command.Password));
        }
    }
}