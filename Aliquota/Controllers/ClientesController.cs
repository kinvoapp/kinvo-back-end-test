using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aliquota.Domain.Entities;
using Aliquota.Applications;

namespace Aliquota.Domain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IAppCliente _appCliente;

        public ClientesController(IAppCliente appCliente)
        {
            _appCliente = appCliente;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<IActionResult> GetCliente()
        {
            return Ok(await _appCliente.Listar());
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var cliente = await _appCliente.ObterPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.ID)
            {
                return BadRequest();
            }

            await _appCliente.Atualizar(cliente);

            return Ok();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostCliente(Cliente cliente)
        {
            await _appCliente.Adicionar(cliente);
            return Ok();
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _appCliente.ObterPorId(id);
            
            if (cliente == null)
                return NotFound();

            await _appCliente.Excluir(cliente);
            return Ok();
        }        
    }
}
