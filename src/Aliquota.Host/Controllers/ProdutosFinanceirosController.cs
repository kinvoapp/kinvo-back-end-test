using Aliquota.Domain.Entidades;
using Aliquota.Domain.Interfaces.Servicos;
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
    public class ProdutosFinanceirosController : ControllerBase
    {
        private readonly ILogger<ProdutosFinanceirosController> logger;
        private readonly IProdutoFinanceiroServico servico;

        public ProdutosFinanceirosController(
            ILogger<ProdutosFinanceirosController> logger,
            IProdutoFinanceiroServico servico)
        {
            this.logger = logger;
            this.servico = servico;
        }

        /// <summary>
        /// Recupera um produto financeiro especifico
        /// </summary>
        /// <param name="id">Id do produto financeiro</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutoFinanceiro), StatusCodes.Status200OK)]
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
        /// Recupera todos os produtos financeiros disponíveis.
        /// </summary>
        [HttpGet("")]
        [ProducesResponseType(typeof(IList<ProdutoFinanceiro>), StatusCodes.Status200OK)]
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
        /// Solicita exclusão de um produto financeiro.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProdutoFinanceiro), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Remover([FromRoute][Required] Guid id)
        {
            logger.LogInformation($"Removendo o produto financeiro: {id}");
            var resultado = await servico.RemoverPorIdAsync(id);
            if (resultado == null)
                return NotFound();
            else
                return Ok(resultado);
        }
    }
}