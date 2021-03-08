using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aliquota.Domain.Entities;
using Aliquota.Applications;

namespace Aliquota.Domain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AplicacoesController : ControllerBase
    {
        private readonly IAppAplicacao _appAplicacao;

        public AplicacoesController(IAppAplicacao appAplicacao)
        {
            _appAplicacao = appAplicacao;
        }

        // GET: api/Aplicacoes
        [HttpGet]
        public async Task<IActionResult> GetAplicacao()
        {
            return Ok(await _appAplicacao.Listar());
        }

        // GET: api/Aplicacoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAplicacao(int id)
        {
            var cliente = await _appAplicacao.ObterPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/Aplicacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAplicacao(int id, Aplicacao aplicacao)
        {
            if (id != aplicacao.ID)
            {
                return BadRequest();
            }

            await _appAplicacao.Atualizar(aplicacao);

            return Ok();
        }

        // POST: api/Aplicacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostAplicacao(Aplicacao aplicacao)
        {
            await _appAplicacao.Adicionar(aplicacao);
            return Ok();
        }

        // DELETE: api/Aplicacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAplicacao(int id)
        {
            var aplicacao = await _appAplicacao.ObterPorId(id);
            
            if (aplicacao == null)
                return NotFound();

            await _appAplicacao.Excluir(aplicacao);
            return Ok();
        }        
    }
}
