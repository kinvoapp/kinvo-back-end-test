using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kinvo.api.Interfaces.IServices;
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
    public class SaldoFundoController : Controller
    {
        private readonly ISaldoFundoService saldoFundoService;

        /// <summary>
        /// Método Construtor Saldo Fundo
        /// </summary>
        /// <param name="SaldoFundoService">Service para o business do saldo fundo</param>
        public SaldoFundoController(ISaldoFundoService pSaldoFundoService)
        {
            this.saldoFundoService = pSaldoFundoService;
        }

        ///<summay>
        /// Salvar Fundo Investimento 
        /// </summary>
        /// <param name="pSaldoFundo"> Parametro contendo o saldo fundo </param>
        /// <return> Salvar de saldo fundo  </returns>
        [HttpPost]
        public ActionResult SalvarSaldoFundo(SaldoFundo pSaldoFundo)
        {
            bool result = false;
            if (pSaldoFundo == null)
            {
                return BadRequest(new Response() { Result = false, Message = "Requisição inválida" });
            }

            result = this.saldoFundoService.SalvarSaldoFundo(pSaldoFundo);

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
        /// Método  obter saldo fundo 
        /// </summary>
        /// <param name="pId">Parametro contendo id do saldo fundo</param>
        /// <returns>Saldo Fundo persistido</returns>
        [HttpGet("ObterSaldoFundo/{inscricao}")]
        public ActionResult ObterSaldoFundo(int pId)
        {
            if (pId == 0)
            {
                return BadRequest(new Response() { Result = false, Message = "Requisição inválida" });
            }

            SaldoFundo lSaldoFundo = this.saldoFundoService.ObterSaldoFundo(pId);

            return Ok(new Response() { Data = lSaldoFundo, Result = true });
        }

    }
}
