using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Application.Interfaces.Services;
using Aliquota.Domain;
using Aliquota.Domain.DTOs;
using Aliquota.Infraestructure.Interfaces.Repositories.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AliquotaController : ControllerBase
    {
        private readonly IAplicacaoFinanceiraService _aplicacaoFinanceiraService;

        public AliquotaController(IAplicacaoFinanceiraService aplicacaoFinanceiraService)
        {
            _aplicacaoFinanceiraService = aplicacaoFinanceiraService;
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            var resultado = _aplicacaoFinanceiraService.ObterTodos();
            if (!resultado.Sucesso)
                return Ok(resultado.MensagemDeErro);

            return Ok(resultado.Dados);
        }

        [HttpGet("ObterPorId")]
        public IActionResult ObterPorId(int id)
        {
            var resultado = _aplicacaoFinanceiraService.ObterPorId(id);
            if (!resultado.Sucesso)
                return BadRequest(resultado.MensagemDeErro);

            return Ok(resultado.Dados);
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar([FromBody] AplicacaoFinanceiraDTO aplicacaoFinanceiraDTO)
        {
            var resultado = _aplicacaoFinanceiraService.Cadastrar(aplicacaoFinanceiraDTO);
            if (!resultado.Sucesso)
                return BadRequest(resultado.MensagemDeErro);

            return Ok(resultado.Dados);
        }

        [HttpPatch("Resgatar")]
        public IActionResult ResgatarAplicacao(int id)
        {
            var resultado = _aplicacaoFinanceiraService.ResgatarAplicacao(id);
            if (!resultado.Sucesso)
                return BadRequest(resultado.MensagemDeErro);

            return Ok(resultado.Dados);
        }
    }
}
