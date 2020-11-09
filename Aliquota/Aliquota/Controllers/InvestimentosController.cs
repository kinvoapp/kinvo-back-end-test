using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aliquota.Domain.Model;
using Aliquota.Domain.Repository;

namespace Aliquota.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestimentosController : ControllerBase
    {
        private readonly AliquotaContext _context;

        public InvestimentosController(AliquotaContext context)
        {
            _context = context;
        }

        // GET: api/Investimentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investimento>>> GetINVESTIMENTOS()
        {
            return await _context.INVESTIMENTOS.ToListAsync();
        }

        // GET: api/Investimentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Investimento>> GetInvestimento(int id)
        {
            var investimento = await _context.INVESTIMENTOS.FindAsync(id);

            if (investimento == null)
            {
                return NotFound();
            }

            return investimento;
        }

        // PUT: api/Investimentos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvestimento(int id, Investimento investimento)
        {
            if (id != investimento.ID)
            {
                return BadRequest();
            }

            _context.Entry(investimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestimentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Investimentos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Investimento>> PostInvestimento(Investimento investimento)
        {
            _context.INVESTIMENTOS.Add(investimento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvestimento", new { id = investimento.ID }, investimento);
        }

        // DELETE: api/Investimentos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Investimento>> DeleteInvestimento(int id)
        {
            var investimento = await _context.INVESTIMENTOS.FindAsync(id);
            if (investimento == null)
            {
                return NotFound();
            }

            _context.INVESTIMENTOS.Remove(investimento);
            await _context.SaveChangesAsync();

            return investimento;
        }

        private bool InvestimentoExists(int id)
        {
            return _context.INVESTIMENTOS.Any(e => e.ID == id);
        }
    }
}
