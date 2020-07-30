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
    public class ResgateFundoController : Controller
    {
        private readonly IResgateFundoService resgateFundoService;

        /// <summary>
        /// Método Construtor Fundo Investimento 
        /// </summary>
        /// <param name="ResgateFundoService">Service para o business do resgate fundo</param>
        public ResgateFundoController(IResgateFundoService pResgateFundoService)
        {
            this.resgateFundoService = pResgateFundoService;
        }

        ///<summay>
        /// Salvar Fundo Investimento 
        /// </summary>
        /// <param name="pResgateFundo"> Parametro contendo o fundo Investimento </param>
        /// <return> Salvar de Fundo Investimento  </returns>
        [HttpPost]
        public ActionResult SalvarResgateFundo(ResgateFundo pResgateFundo)
        {
            bool result = false;
            if (pResgateFundo == null)
            {
                return BadRequest(new Response() { Result = false, Message = "Requisição inválida" });
            }

            result = this.resgateFundoService.SalvarResgateFundo(pResgateFundo);

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
        /// Método  obter resgate fundo 
        /// </summary>
        /// <param name="pId">Parametro contendo id do fundo investimento</param>
        /// <returns>Fundo de investimento persistido</returns>
        [HttpGet("ObterResgateFundo/{inscricao}")]
        public ActionResult ObterResgateFundo(int pId)
        {
            if (pId == 0)
            {
                return BadRequest(new Response() { Result = false, Message = "Requisição inválida" });
            }

            ResgateFundo lResgateFundo = this.resgateFundoService.ObterResgateFundo(pId);

            return Ok(new Response() { Data = lResgateFundo, Result = true });
        }

    }
}
