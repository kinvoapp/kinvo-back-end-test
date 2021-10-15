using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aliquota.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Aliquota.Domain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RescuesController : ControllerBase
    {
        private readonly Context _context;

        public RescuesController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém a lista das aplicações resgatas.
        /// </summary>
        [SwaggerResponse(statusCode: 200, description: "Requisição bem sucedida", Type = typeof(Application))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(GenericError))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rescue>>> GetRescues()
        {
            return await _context.Rescues.ToListAsync();
        }

        /// <summary>
        /// Obtém a lista das aplicações resgatas por Id.
        /// </summary>
        [SwaggerResponse(statusCode: 200, description: "Requisição bem sucedida", Type = typeof(Application))]
        [SwaggerResponse(statusCode: 400, description: "Objeto não encontrado", Type = typeof(ErrorList))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(GenericError))]
        [HttpGet("{id}")]
        public async Task<ActionResult<Rescue>> GetRescue(int id)
        {
            var rescue = await _context.Rescues.FindAsync(id);

            if (rescue == null)
            {
                return NotFound();
            }

            return rescue;
        }


        /// <summary>
        /// Deleta um resgate.
        /// </summary>
        [SwaggerResponse(statusCode: 204, description: "Sucesso ao Deletar", Type = typeof(Application))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(GenericError))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRescue(int id)
        {
            var rescue = await _context.Rescues.FindAsync(id);
            if (rescue == null)
            {
                return NotFound();
            }

            _context.Rescues.Remove(rescue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
    }
}
