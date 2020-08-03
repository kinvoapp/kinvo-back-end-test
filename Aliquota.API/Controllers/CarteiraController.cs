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
    public class CarteiraController : ControllerBase
    {
        private readonly IAliquotaService Aliquota;

        public CarteiraController(IAliquotaService aliquota)
        {
            Aliquota = aliquota;
        }

        // GET: api/Investimento
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string nome)
        {
            var model = await Aliquota.GetCarteiraByNomeAsync(nome).ConfigureAwait(false);

            return Ok(model);
        }

        // POST: api/Investimento
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarteiraPostViewModel carteira)
        {
            return Created("", await Aliquota.
                AdicionarCarteira(carteira.Nome).ConfigureAwait(false));
        }
    }
}
