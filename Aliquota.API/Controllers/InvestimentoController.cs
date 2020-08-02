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
    public class InvestimentoController : ControllerBase
    {
        private readonly IAliquotaService Aliquota;

        public InvestimentoController(IAliquotaService aliquota)
        {
            Aliquota = aliquota;
        }

        // GET: api/Investimento
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]Guid carteiraId)
        {
            var model = await Aliquota.GetInvestimentosAsync(carteiraId).ConfigureAwait(false);

            return Ok(model);
        }

        // POST: api/Investimento
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InvestimentoPostViewModel model)
        {
            return Created("", await Aliquota.
                AdicionarInvestimento((uint)model.Id, model.CarteiraGuid, model.ValorInvestimento).ConfigureAwait(false));
        }


    }
}
