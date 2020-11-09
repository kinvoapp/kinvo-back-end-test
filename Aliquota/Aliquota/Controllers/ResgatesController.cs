using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aliquota.Domain.Model;
using Aliquota.Domain.Repository;
using System.Net;
using System.Globalization;

namespace Aliquota.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResgatesController : ControllerBase
    {     

        private readonly AliquotaContext _context;

        public ResgatesController(AliquotaContext context)
        {
            _context = context;
        }

        // GET: api/Resgates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resgate>>> GetRESGATES()
        {
            return await _context.RESGATES.ToListAsync();
        }

        // GET: api/Resgates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resgate>> GetResgate(int id)
        {
            var resgate = await _context.RESGATES.FindAsync(id);

            if (resgate == null)
            {
                return NotFound();
            }

            return resgate;
        }

        // PUT: api/Resgates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResgate(int id, Resgate resgate)
        {
            if (id != resgate.ID)
            {
                return BadRequest();
            }

            _context.Entry(resgate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResgateExists(id))
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

        // POST: api/Resgates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Resgate>> PostResgate(Resgate resgate)
        {
            //Pesquisar o investimento do cliente pelo CPF

            // Validar valor de retirada de resgate.

            // Permitir somente o valor total

            // Quando tiver o investimento em maos calcular o lucro do cliente

            // Após o lucro obtido, calcular e retornar a aliquota do IR e retornar o valor do imposto.

            _context.RESGATES.Add(resgate);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResgate", new { id = resgate.ID }, resgate);
        }

        // DELETE: api/Resgates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Resgate>> DeleteResgate(int id)
        {
            var resgate = await _context.RESGATES.FindAsync(id);
            if (resgate == null)
            {
                return NotFound();
            }

            _context.RESGATES.Remove(resgate);
            await _context.SaveChangesAsync();

            return resgate;
        }

        private bool ResgateExists(int id)
        {
            return _context.RESGATES.Any(e => e.ID == id);
        }

        private decimal CalcLucro(decimal percentual , decimal vlInvestimento)
        {
            if (vlInvestimento == 0) 
            {
                return 0.0M;
            }

            decimal resultado = (percentual / 100) * vlInvestimento;

            return resultado;
        }

        public static DateTime DataAtual()
        {
            var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
            var response = myHttpWebRequest.GetResponse();
            string todaysDates = response.Headers["date"];
            return DateTime.ParseExact(todaysDates,
                                       "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                                        CultureInfo.InvariantCulture.DateTimeFormat,
                                        DateTimeStyles.AssumeUniversal);
        }

    }
}
