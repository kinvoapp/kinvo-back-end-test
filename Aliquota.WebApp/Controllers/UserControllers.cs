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
    [ApiController]
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
        public async Task<RequestResult<UserModel>> CreateUser([FromBody] CreateUserCommand command)
        {
            
            var user = await userHandler.HandleAsync(command);

            if (user == null) {
                return new RequestResult<UserModel> {
                    Success = false,
                    Message = $"O email {command.Email} já foi cadastrado",
                    Data = null,
                };
            }

            await context.SaveChangesAsync();

            return new RequestResult<UserModel> {
                Success = true,
                Message = "Usuário cadastrado com sucesso!",
                Data = mc.ToModel(user),
            };
        }

        [HttpPost("login")]
        public async Task<RequestResult<AuthenticationResponse>> LoginUser([FromBody] LoginCommand command)
        {
            var user = await userRepository.GetUserByEmailAsync(command.Email);

            if (user == null || !user.VerifyPassword(command.Password))
            {
                return new RequestResult<AuthenticationResponse> {
                    Success = false,
                    Message = "Email ou senha incorretos",
                    Data = null,
                };
            }

            return new RequestResult<AuthenticationResponse> {
                Success = true,
                Message = "Autenticação realizada com sucesso!",
                Data = new AuthenticationResponse {
                    Token = tokenService.GenerateToken(user),
                    User = mc.ToModel(user),
                },
            };
        }
    }
}