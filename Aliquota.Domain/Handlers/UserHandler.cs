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
        private readonly IContext context;

        public UserHandler(IUserRepository userRepository, IContext context, IPortfolioRepository portfolioRepository)
        {
            this.userRepository = userRepository;
            this.context = context;
            this.portfolioRepository = portfolioRepository;
        }

        public async Task<User> HandleAsync(CreateUserCommand command) {
            var portfolio = new Portfolio();
            var user = new User(command.Email, command.FullName, portfolio);
            user.SetPassword(command.Password);

            userRepository.Add(user);
            portfolioRepository.Add(portfolio);
            await context.SaveChangesAsync();

            return user;
        }
    }
}