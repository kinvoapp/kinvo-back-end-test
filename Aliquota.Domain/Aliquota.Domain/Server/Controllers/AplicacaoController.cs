using Aliquota.Domain.Server.Data;
using Aliquota.Domain.Shared.Models;
using Aliquota.Domain.Shared.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AplicacaoController
        : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AplicacaoController(ApplicationDbContext _context)
        {
            context = _context;
        }

        #region GET

        [HttpGet]
        public async Task<ActionResult<List<Aplicacao>>> Get()
        {
            return await context.Aplicacaos.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<Aplicacao>> GetById(int id)
        {
            return await context.Aplicacaos.FirstOrDefaultAsync(x => x.Id == id);
        }

        #endregion

        #region POST

        [HttpPost]
        public async Task<ActionResult> Post(Aplicacao aplicacao)
        {
            aplicacao.Ativo = true;
            aplicacao.DataAplicacao = DateTime.Now;
            aplicacao.DataRetirada = aplicacao.DataAplicacao.AddMonths(aplicacao.PeriodoPrevistoAplicadoEmMeses);
            
            context.Add(aplicacao);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult(nameof(GetById), new { aplicacao.Id }, aplicacao);
        }

        #endregion

        #region PUT

        [HttpPut]
        public async Task<ActionResult> Put(Aplicacao aplicacao)
        {
            if (!aplicacao.Ativo) return NoContent();

            context.Entry(aplicacao).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        [Route("retirar")]
        public async Task<ActionResult> Retirar(Aplicacao aplicacao)
        {
            var rentabilidade = aplicacao.ValorTotal - aplicacao.ValorInvestido;
            var dias = Utilitarios.CalculaDias(aplicacao.DataAplicacao, aplicacao.DataRetirada);
            var aliquota = Utilitarios.CalculaAliquota(dias);
            var valorIR = Utilitarios.ImpostoDeRenda((double)rentabilidade, aliquota);

            aplicacao.Ativo = false;
            aplicacao.ValorSacado = aplicacao.ValorTotal - valorIR;

            context.Entry(aplicacao).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent(); 
        }

        #endregion

        #region DELETE

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var aplicacao = await context.Aplicacaos.FirstOrDefaultAsync(x => x.Id == id);

            if (!aplicacao.Ativo) return NoContent();

            context.Remove(aplicacao);
            await context.SaveChangesAsync();
            return NoContent();
        }

        #endregion
    }
}
