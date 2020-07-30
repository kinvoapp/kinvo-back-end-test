using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using src.Interfaces.IServices;
using src.Models;
using src.ViewModels;

namespace backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AplicacaoFundoController : Controller
    {
        private readonly IAplicacaoFundoService aplicacaoFundoService;

        /// <summary>
        /// Método Construtor da aplicacao do fundo
        /// </summary>
        /// <param name="AplicacaoFundoService">Service para o business do aplicacao fundo</param>
        public AplicacaoFundoController(IAplicacaoFundoService pAplicacaoFundoService)
        {
            this.aplicacaoFundoService = pAplicacaoFundoService;
        }

        ///<summay>
        /// Salvar Fundo Investimento 
        /// </summary>
        /// <param name="pAplicacaoFundo"> Parametro contendo o aplicacao fundo </param>
        /// <return> Salvar de Fundo Investimento  </returns>
        [HttpPost]
        public ActionResult SalvarAplicacaoFundo(AplicacaoFundo pAplicacaoFundo)
        {
            bool result = false;
            if (pAplicacaoFundo == null)
            {
                return BadRequest(new Response() { Result = false, Message = "Requisição inválida" });
            }

            result = this.aplicacaoFundoService.SalvarAplicacaoFundo(pAplicacaoFundo);

            if (result)
            {
                return Ok(new Response() { Message = "Cadastrado com sucesso com Sucesso", Result = true });
            }
            else
            {
                return Ok(new Response() { Message = "Falha ao atualizar", Result = false });
            }
        }

        /// <summary>
        /// Método  obter aplicacao fundo 
        /// </summary>
        /// <param name="pId">Parametro contendo id do aplicacao fundo</param>
        /// <returns>Fundo de investimento persistido</returns>
        [HttpGet("ObterAplicacaoFundo/{inscricao}")]
        public ActionResult ObterAplicacaoFundo(int pId)
        {
            if (pId == 0)
            {
                return BadRequest(new Response() { Result = false, Message = "Requisição inválida" });
            }

            AplicacaoFundo lAplicacaoFundo = this.aplicacaoFundoService.ObterAplicacaoFundo(pId);

            return Ok(new Response() { Data = lAplicacaoFundo, Result = true });
        }

    }
}
