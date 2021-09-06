using KinvoTeste.Domain.Service;
using KinvoTeste.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace KinvoTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(ILogger<ProdutoController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public int Add([FromBody] Produto produto)
        {
            return new ProdutoService().Add(produto);
        }

        [HttpGet("{idUsuario}")]
        public List<Resgate> Resgatar(int idUsuario)
        {
            return new ProdutoService().Resgatar(idUsuario, DateTime.Now);
        }

        [HttpGet("{idUsuario}/{dataResgate}/simular")]
        public List<Resgate> Simular(int idUsuario, DateTime dataResgate)
        {
            return new ProdutoService().Resgatar(idUsuario, dataResgate, true);
        }
    }
}
