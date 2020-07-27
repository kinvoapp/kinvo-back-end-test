using Aliquota.API.Factory;
using Aliquota.API.Requests;
using Aliquota.API.Responses;
using Aliquota.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Aliquota.API.Controllers
{
    [Route("investimento/[controller]")]
    [ApiController]
    public class AplicacaoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public AplicacaoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("{id}")]
        public IActionResult Obter(Guid id)
        {
            var aplicacao = _produtoService.ObterPorId(id);

            if (aplicacao == null)
            {
                return NotFound($"Aplicação com id {id} não encontrada.");
            }

            return Ok(AplicacaoResponse.Criar(aplicacao));
        }


        [HttpGet]
        public IActionResult ObterTodos()
        {
            var aplicacoes = _produtoService.ObterTodos();

            var retorno = aplicacoes.Select(x => AplicacaoResponse.Criar(x));

            return Ok(retorno);
        }

        [HttpPost]
        public IActionResult Aplicar(AplicacaoRequest aplicacaoRequest)
        {
            var aplicacao = AplicacaoFactory.Criar(aplicacaoRequest);

            if (!aplicacao.EValida())
            {
                return BadRequest($"Valor da aplicação precisa ser maior do que zero.");
            }

            aplicacao = _produtoService.Aplicar(aplicacao);

            return Created($"/{aplicacao.Id}", AplicacaoResponse.Criar(aplicacao));
        }

        [HttpGet("{AplicacaoId}/resgate")]
        public IActionResult ObterResgate(Guid AplicacaoId)
        {
            var aplicacao = _produtoService.ObterPorId(AplicacaoId);

            if (aplicacao == null)
            {
                return NotFound($"Aplicação com id {AplicacaoId} não encontrada.");

            }
            if (!aplicacao.Resgatado)
            {
                return NotFound($"Aplicação ainda não foi resgatada.");
            }

            return Ok(ResgateResponse.Criar(aplicacao.Resgate));
        }

        [HttpPost("{AplicacaoId}/resgate")]
        public IActionResult Resgatar(ResgateRequest resgateRequest, Guid AplicacaoId)
        {
            var aplicacao = _produtoService.ObterPorId(AplicacaoId);

            if (aplicacao == null)
            {
                return NotFound($"Aplicação com id {AplicacaoId} não encontrada.");
            }

            if (!aplicacao.PodeResgatar(resgateRequest.Data))
            {
                return BadRequest($"Data deve ser superior a data da aplicação {aplicacao.Data.ToString("dd/MM/yyyy HH:mm:ss")}.");
            }

            if (aplicacao.Resgatado)
            {
                return BadRequest($"Aplicação já foi resgatada na data {aplicacao.Resgate.Data.ToString("dd/MM/yyyy HH:mm:ss")}.");
            }
            var resgate = _produtoService.Resgatar(aplicacao, resgateRequest.Data);

            return Ok(ResgateResponse.Criar(resgate));
        }

        [HttpPost("resgate/disponiveis")]
        public IActionResult ResgatarDisponiveis(ResgateRequest resgateRequest)
        {
            var resgate = _produtoService.ResgatarTodosDisponiveis(resgateRequest.Data);

            return Ok(resgate.Select(x => ResgateResponse.Criar(x)));
        }

    }
}
