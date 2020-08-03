using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.API.ViewModel;
using Aliquota.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IAliquotaService Aliquota;

        public ProdutoController(IAliquotaService aliquota)
        {
            Aliquota = aliquota;
        }
        // GET: api/Produto
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await Aliquota.GetProdutosAsync().ConfigureAwait(false);
            return Ok(model);
        }

        // GET: api/Produto/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await Aliquota.GetProdutoByIdAsync((uint)id);
            return Ok(model);
        }

        // POST: api/Produto
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProdutoPostViewModel produto)
        {
            var model = await Aliquota.AdicionarProduto((uint)produto.Id,produto.Nome,produto.TaxaAnual,produto.Vencimento);
            return Created("", model);
        }

    }
}
