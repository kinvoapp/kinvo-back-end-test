using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aliquota.Domain.Entities;
using Aliquota.Applications;

namespace Aliquota.Domain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosFinanceirosController : ControllerBase
    {
        private readonly IAppProdutoFinanceiro _appProdutoFinanceiro;

        public ProdutosFinanceirosController(IAppProdutoFinanceiro appProdutoFinanceiro)
        {
            _appProdutoFinanceiro = appProdutoFinanceiro;
        }

        // GET: api/ProdutosFinanceiros
        [HttpGet]
        public async Task<IActionResult> GetProdutosFinanceiros()
        {
            return Ok(await _appProdutoFinanceiro.Listar());
        }

        // GET: api/ProdutosFinanceiros/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdutoFinanceiro(int id)
        {
            var ProdutoFinanceiro = await _appProdutoFinanceiro.ObterPorId(id);

            if (ProdutoFinanceiro == null)
            {
                return NotFound();
            }

            return Ok(ProdutoFinanceiro);
        }

        // PUT: api/ProdutosFinanceiros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdutoFinanceiro(int id, ProdutoFinanceiro produtoFinanceiro)
        {
            if (id != produtoFinanceiro.ID)
            {
                return BadRequest();
            }

            await _appProdutoFinanceiro.Atualizar(produtoFinanceiro);

            return Ok();
        }

        // POST: api/ProdutosFinanceiros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostProdutoFinanceiro(ProdutoFinanceiro produtoFinanceiro)
        {
            await _appProdutoFinanceiro.Adicionar(produtoFinanceiro);
            return Ok();
        }

        // DELETE: api/ProdutosFinanceiros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdutoFinanceiro(int id)
        {
            var ProdutoFinanceiro = await _appProdutoFinanceiro.ObterPorId(id);
            
            if (ProdutoFinanceiro == null)
                return NotFound();

            await _appProdutoFinanceiro.Excluir(ProdutoFinanceiro);
            return Ok();
        }        
    }
}
