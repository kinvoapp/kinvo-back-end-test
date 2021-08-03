using Aliquota.Domain.Entidades;
using Aliquota.Domain.Interfaces.Servicos;
using Aliquota.Domain.Mediadores.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Aliquota.Host.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AplicacaoFinanceiraController : ControllerBase
    {
        private readonly ILogger<AplicacaoFinanceiraController> logger;
        private readonly IAplicacaoFinanceiraServico servico;

        public AplicacaoFinanceiraController(
            ILogger<AplicacaoFinanceiraController> logger,
            IAplicacaoFinanceiraServico servico)
        {
            this.logger = logger;
            this.servico = servico;
        }

        /// <summary>
        /// Recupera uma aplicação financeira específica
        /// </summary>
        /// <param name="id">Id da aplicação financeira</param>
        /// <returns>Uma aplicação financeira</returns>
        [HttpGet("{id}", Name = "AplicacaoFinanceira-ObterPorId")]
        [ProducesResponseType(typeof(AplicacaoFinanceira), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterPorId([FromRoute][Required] Guid id)
        {
            logger.LogInformation($"Obtendo o produto financeiro: {id}");
            var resultado = await servico.ObterPorIdAsync(id);
            if (resultado == null)
                return NotFound();
            else
                return Ok(resultado);
        }

        /// <summary>
        /// Recupera todos os produtos financeiros disponíveis
        /// </summary>
        /// <returns>Todas as aplicações financeiras</returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(IList<AplicacaoFinanceira>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterTodos()
        {
            logger.LogInformation("Obtendo todos os produtos financeiros");
            var resultado = await servico.ObterTodosAsync();

            if (resultado == null || resultado.Count == 0)
                return NotFound();
            else
                return Ok(resultado);
        }

        /// <summary>
        /// Solicita a criação de uma aplicacao financeira
        /// </summary>
        /// <param name="comando"></param>
        /// <returns>Uma aplicação financeira inserida</returns>
        [HttpPost]
        [ProducesResponseType(typeof(AplicacaoFinanceira), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Inserir([FromBody] InserirAplicacaoFinanceiraCommand comando)
        {
            var resultado = await servico.Inserir(comando);
            return CreatedAtRoute("AplicacaoFinanceira-ObterPorId", new { id = resultado.Id }, resultado);
        }

        /// <summary>
        /// Solicita o resgate da aplicação financeira e excluí do banco.
        /// </summary>
        /// <param name="id">Id da aplicação financeira</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AplicacaoFinanceira), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Resgatar([FromRoute][Required] Guid id)
        {
            logger.LogInformation($"Removendo o produto financeiro: {id}");
            var resultado = await servico.ResgatarPorIdAsync(id);
            if (resultado == null)
                return NotFound();
            else
                return Ok(resultado);
        }
    }
}