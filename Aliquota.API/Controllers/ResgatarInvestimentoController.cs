using System;
using System.Threading.Tasks;
using Aliquota.API.ViewModel;
using Aliquota.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResgatarInvestimentoController : ControllerBase
    {
        private readonly IAliquotaService Aliquota;

        public ResgatarInvestimentoController(IAliquotaService aliquota)
        {
            Aliquota = aliquota;
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid investimentoId,[FromBody] ResgatarInvestimentoViewModel model)
        {
            var response = await Aliquota.RealizarSaqueInvestimento(investimentoId, model.DataResgate);
            return Ok(response);
        }
    }
}
