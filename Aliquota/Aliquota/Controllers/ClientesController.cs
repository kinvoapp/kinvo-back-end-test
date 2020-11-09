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
    public class ClientesController : ControllerBase
    {
        private readonly AliquotaContext _context;

        public ClientesController(AliquotaContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCLIENTES()
        {
            return await _context.CLIENTES.ToListAsync();
        }

        // GET: api/Clientes/cpf
        [HttpGet("{cpf}")]
        public async Task<ActionResult<decimal>> GetCliente(string cpf)
        {
            //var cliente = await _context.CLIENTES.Where(c => c.Cpf == cpf).Select(c => c.ID).SingleOrDefaultAsync();

            var cliente = await _context.CLIENTES.Where(c => c.Cpf == cpf).SingleOrDefaultAsync();

            if (cliente == null)
            {
                return NotFound();
            }
            decimal imposto = await CalcularImposto(cliente.ID);
            return Ok(imposto);
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.ID)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.CLIENTES.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.ID }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> DeleteCliente(int id)
        {
            var cliente = await _context.CLIENTES.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.CLIENTES.Remove(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        private bool ClienteExists(int id)
        {
            return _context.CLIENTES.Any(e => e.ID == id);
        }

        private async Task<decimal> CalcularImposto(int clientId)
        {
           
            Investimento investimento = await _context.INVESTIMENTOS.Where(i => i.ClienteID == clientId).SingleOrDefaultAsync();
            var diasAplicados = ConverterDataDias(investimento.DataAplicacao);
            var lucro = CalculaLucroInvestimento(investimento);
            decimal aliquota = 0;
            if (diasAplicados <= 365)
            {
                aliquota = 22.5M;
            }else if (diasAplicados > 365 && diasAplicados <= 730)
            {
                aliquota = 18.5M;
            }
            else if(diasAplicados > 730)
            {
                aliquota = 15;
            }
            var impostoDevido = lucro * (aliquota/100);
            return impostoDevido;
        }

        private int ConverterDataDias(DateTime dataAplicacao)
        {
            DateTime futurDate = Convert.ToDateTime(dataAplicacao);
            DateTime TodayDate = DateTime.Now;
            var numberOfDays = (futurDate - TodayDate).TotalDays;
            return (int)numberOfDays;
        }

        private decimal CalculaLucroInvestimento(Investimento investimento)
        {
            return (investimento.PercentLucro / 100) * investimento.VlInvest;
        }
    }
}
