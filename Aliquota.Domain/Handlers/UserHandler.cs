using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Aliquota.Domain.Commands;
using Aliquota.Domain.Contracts.Repositories;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Handlers {
    public class UserHandler {
        private readonly IUserRepository userRepository;
        private readonly IPortfolioRepository portfolioRepository;

        public UserHandler(IUserRepository userRepository, IPortfolioRepository portfolioRepository)
        {
            this.userRepository = userRepository;
            this.portfolioRepository = portfolioRepository;
        }

        public User Handle(CreateUserCommand command) {
            var portfolio = new Portfolio();
            var user = new User(command.Email, command.FullName, portfolio);
            user.SetPassword(command.Password);

            userRepository.Add(user);
            portfolioRepository.Add(portfolio);

            return user;
        }
    }
}