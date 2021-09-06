using KinvoTeste.Domain.Service;
using KinvoTeste.Helper;
using KinvoTeste.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KinvoTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        public int Add([FromBody] Usuario usuario)
        {
            return new UsuarioService().Add(usuario);
        }

        [HttpGet]
        public List<Usuario> GetAll()
        {
            return new UsuarioService().GetAll();
        }

        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            return new UsuarioService().Get(id);
        }

        [HttpPatch("{id}")]
        public void Update(int id, [FromBody] Usuario usuario)
        {
            new UsuarioService().Update(id, usuario);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new UsuarioService().Delete(id);
        }

        [AllowAnonymous]
        [HttpGet("{login}/{senha}/login")]
        public Usuario login(string login, string senha)
        {
            var usuario = new UsuarioService().Login(login, senha);
            if (usuario != null)
            {
                usuario.Token = TokenHelper.GenerateToken(usuario);
                return usuario;
            }

            return null;
        }
    }
}
