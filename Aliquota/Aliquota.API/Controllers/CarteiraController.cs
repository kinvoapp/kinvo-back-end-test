using Aliquota.Data.Context;
using Aliquota.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarteiraController : ControllerBase
    {
        private readonly AliquotaContext context;
        public CarteiraController(AliquotaContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public IActionResult PostCarteiraAsync([FromBody]Carteira carteira )
        { 
            context.Add(carteira);
            return Ok("Carteira salva");
        }
        
    }
}
