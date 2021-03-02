using Aliquota.Domain.AggregatesModel.ProdutoFinanceiroAggregate;
using Aliquota.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoFinanceiroesController : ControllerBase
    {
        private readonly AliquotaContext _context;

        public ProdutoFinanceiroesController(AliquotaContext context)
        {
            _context = context;
        }

        // GET: api/ProdutoFinanceiroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoFinanceiro>>> GetprodutoFinanceiros()
        {
            return await _context.produtoFinanceiros.ToListAsync();
        }

        // GET: api/ProdutoFinanceiroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoFinanceiro>> GetProdutoFinanceiro(int id)
        {
            var produtoFinanceiro = await _context.produtoFinanceiros.FindAsync(id);

            if (produtoFinanceiro == null)
            {
                return NotFound();
            }

            return produtoFinanceiro;
        }

        // PUT: api/ProdutoFinanceiroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdutoFinanceiro(int id, ProdutoFinanceiro produtoFinanceiro)
        {
            if (id != produtoFinanceiro.Id)
            {
                return BadRequest();
            }

            _context.Entry(produtoFinanceiro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoFinanceiroExists(id))
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

        // POST: api/ProdutoFinanceiroes/taxa 10/10
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{descricao}/{taxaDeRendimento}")]
        public async Task<ActionResult<ProdutoFinanceiro>> PostProdutoFinanceiro(string descricao, double taxaDeRendimento)
        {
            ProdutoFinanceiro produtoFinanceiro = new ProdutoFinanceiro(descricao, taxaDeRendimento);
            _context.produtoFinanceiros.Add(produtoFinanceiro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdutoFinanceiro", new { id = produtoFinanceiro.Id }, produtoFinanceiro);
        }

        // DELETE: api/ProdutoFinanceiroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdutoFinanceiro(int id)
        {
            var produtoFinanceiro = await _context.produtoFinanceiros.FindAsync(id);
            if (produtoFinanceiro == null)
            {
                return NotFound();
            }

            _context.produtoFinanceiros.Remove(produtoFinanceiro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoFinanceiroExists(int id)
        {
            return _context.produtoFinanceiros.Any(e => e.Id == id);
        }
    }
}
