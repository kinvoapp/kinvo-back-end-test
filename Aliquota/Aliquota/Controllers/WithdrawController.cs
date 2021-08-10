using System.Threading.Tasks;
using Aliquota.Application.Features.Withdraws.Queries;
using Aliquota.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.Controllers
{
    public class WithdrawController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllWithdrawsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] decimal id)
        {
            return Ok(await Mediator.Send(new GetWithdrawByIdQuery() { Id = id}));
        }
    }
}
