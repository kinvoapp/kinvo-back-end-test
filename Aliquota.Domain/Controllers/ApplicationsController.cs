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
    public class ApplicationsController : ControllerBase
    {
        private readonly Context _context;

        public ApplicationsController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém a lista das aplicações Realizadas.
        /// </summary>
        [SwaggerResponse(statusCode: 200, description: "Requisição bem sucedida", Type = typeof(Application))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(GenericError))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplications()
        {
            return await _context.Applications.ToListAsync();
        }

        /// <summary>
        /// Obtém a lista das aplicações Realizadas por Id.
        /// </summary>
        [SwaggerResponse(statusCode: 200, description: "Requisição bem sucedida", Type = typeof(Application))]
        [SwaggerResponse(statusCode: 400, description: "Objeto não encontrado", Type = typeof(ErrorList))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(GenericError))]
        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> GetApplication(int id)
        {
            var application = await _context.Applications.FindAsync(id);

            if (application == null)
            {
                return NotFound();
            }

            return application;
        }

        /// <summary>
        /// Edita uma aplicação.
        /// </summary>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar", Type = typeof(Application))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ErrorList))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(GenericError))]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplication(int id, Application application)
        {
            if (id != application.ApplicationID)
            {
                return BadRequest();
            }

            _context.Entry(application).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(id))
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

        /// <summary>
        /// Cria uma nova aplicação.
        /// </summary>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar", Type = typeof(Application))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ErrorList))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(GenericError))]
        [HttpPost]
        public async Task<ActionResult<Application>> PostApplication(Application application)
        {
            _context.Applications.Add(application);

            //Valida se a data de aplicação é igual, anterior ou posterior a data de resgate
            int DateValidation = DateTime.Compare(application.ApplicationRescue, application.ApplicationDate);

            if (DateValidation < 0)
            {
                return BadRequest("A Data de Resgate não pode ser inferior a data de aplicação.");
            }

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetApplication", new { id = application.ApplicationID }, application);

        }

        /// <summary>
        /// Implementar o nome desse método no front-end como "Resgatar Aplicação".
        /// Deleta da tabela atual, envia a "aplicação" para entidade "Resgates".
        /// </summary>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao Deletar", Type = typeof(Application))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(GenericError))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }

            //Transferindo o valor aplicado para a view "Rescue"
            try
            {
                Rules rules = new();
                Rescue rescue = rules.Rescue(application);
                _context.Rescues.Add(rescue);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool ApplicationExists(int id)
        {
            return _context.Applications.Any(e => e.ApplicationID == id);
        }
    }
}
