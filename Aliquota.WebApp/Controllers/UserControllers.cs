using System.Threading.Tasks;
using Aliquota.Domain.Commands;
using Aliquota.Domain.Contracts.Repositories;
using Aliquota.Domain.Handlers;
using Aliquota.Persistence.Context;
using Aliquota.WebApp.Commands;
using Aliquota.WebApp.Models;
using Aliquota.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.WebApp.Controllers
{
    [Route("/api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserHandler userHandler;
        private readonly IUserRepository userRepository;
        private readonly TokenService tokenService;
        private readonly AppDbContext context;
        private readonly ModelConverter mc;

        public UserController(UserHandler userHandler,
                              IUserRepository userRepository,
                              TokenService tokenService,
                              AppDbContext context,
                              ModelConverter mc)
        {
            this.userHandler = userHandler;
            this.userRepository = userRepository;
            this.tokenService = tokenService;
            this.context = context;
            this.mc = mc;
        }

        [HttpPost]
        public async Task<UserModel> CreateUser([FromBody] CreateUserCommand command)
        {
            
            var user = userHandler.Handle(command);
            await context.SaveChangesAsync();

            return mc.ToModel(user);
        }

        [HttpPost("login")]
        public async Task<AuthenticationResponse> LoginUser([FromBody] LoginCommand command)
        {
            var user = await userRepository.GetUserByEmailAsync(command.Email);

            if (user == null || !user.VerifyPassword(command.Password))
            {
                return new AuthenticationResponse {
                    Success = false,
                };
            }

            return new AuthenticationResponse {
                Success = true,
                Token = tokenService.GenerateToken(user),
                User = mc.ToModel(user),
            };
        }
    }
}