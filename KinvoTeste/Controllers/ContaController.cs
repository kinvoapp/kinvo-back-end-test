using KinvoTeste.Domain.Service;
using KinvoTeste.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KinvoTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ContaController : ControllerBase
    {
        private readonly ILogger<ContaController> _logger;

        public ContaController(ILogger<ContaController> logger)
        {
            _logger = logger;
        }

        [HttpPatch("{id}")]
        public int? Add(int id, [FromBody] double valor)
        {
            return new ContaService().Atualizar(id, valor);
        }

    }
}
