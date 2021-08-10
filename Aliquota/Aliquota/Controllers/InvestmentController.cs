using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aliquota.Application.Features.Investments.Commands;
using Aliquota.Application.Features.Investments.DTOs;
using Aliquota.Application.Features.Investments.Queries;
using Aliquota.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.Controllers
{
    public class InvestmentController : ApiBaseController
    {
        [HttpGet]
        public async Task<IEnumerable<InvestmentDTO>> GetAll()
        {
            return await Mediator.Send(new GetAllInvestmentsQuery());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] decimal id)
        {
            return Ok(await Mediator.Send(new GetInvestmentByIdQuery(){Id = id}));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInvestmentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("Withdraw/{id}")]
        public async Task<IActionResult> Withdraw(decimal id, [FromBody] DateTime withdraw)
        {
            return Ok(await Mediator.Send(new CreateWithdrawInvestmentCommand {Id = id, WithdrawDate = withdraw}));
        }
    }
}