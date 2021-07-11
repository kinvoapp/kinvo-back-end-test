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

        public async Task<User> HandleAsync(CreateUserCommand command) {
            var existingUser = await userRepository.GetUserByEmailAsync(command.Email);

            if(existingUser != null) {
                return null;
            }
 
            var portfolio = new Portfolio();
            var user = new User(command.Email, command.FullName);
            user.SetPassword(command.Password);
            portfolio.Owner = user;

            portfolioRepository.Add(portfolio);
            userRepository.Add(user);

            return user;
        }
    }
}