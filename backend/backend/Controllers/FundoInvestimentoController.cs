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
    public class FundoInvestimentoController : Controller
    {
        private readonly IFundoInvestimentoService fundoInvestimentoService;

        /// <summary>
        /// Método Construtor Fundo Investimento 
        /// </summary>
        /// <param name="FundoInvestimentoService">Service para o business do fundo de investimento</param>
        public FundoInvestimentoController(IFundoInvestimentoService pFundoInvestimentoService)
        {
            this.fundoInvestimentoService = pFundoInvestimentoService;
        }

        ///<summay>
        /// Salvar Fundo Investimento 
        /// </summary>
        /// <param name="pFundoInvestimento"> Parametro contendo o fundo Investimento </param>
        /// <return> Lista de Papel de trabalho </returns>
        [HttpPost]
        public ActionResult SalvarFundoInvestimento(FundoInvestimento pFundoInvestimento)
        {
            bool result = false;
            if (pFundoInvestimento == null)
            {
                return BadRequest(new Response() { Result = false, Message = "Requisição inválida" });
            }

            result = this.fundoInvestimentoService.SalvarFundoInvestimento(pFundoInvestimento);

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
        /// Método  obter fundo de investimento 
        /// </summary>
        /// <param name="pId">Parametro contendo id do fundo investimento</param>
        /// <returns>Fundo de investimento persistido</returns>
        [HttpGet("ObterPapelTrabalho/{inscricao}")]
        public ActionResult ObterFundoInvestimento(int pId)
        {
            if (pId == 0)
            {
                return BadRequest(new Response() { Result = false, Message = "Requisição inválida" });
            }

            FundoInvestimento lFundoInvestimento = this.fundoInvestimentoService.ObterFundoInvestimento(pId);

            return Ok(new Response() { Data = lFundoInvestimento, Result = true });
        }

    }
}
