using System.Collections.Generic;
using System.Threading.Tasks;
using Aliquota.Application.Features.FinancialProducts.Commands;
using Aliquota.Application.Features.FinancialProducts.DTO;
using Aliquota.Application.Features.FinancialProducts.Queries;
using Aliquota.Application.Features.FinancialProductss.Queries;
using Aliquota.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialProductController : ApiBaseController
    {
        [HttpGet]
        public async Task<IEnumerable<FinancialProductDTO>> GetAll()
        {
            return await Mediator.Send(new GetAllFinancialProductQuery());
        }

        [HttpGet("{id}")]
        public async Task<FinancialProductDTO> Get([FromRoute] decimal id)
        {
            return await Mediator.Send(new GetFinancialProductByIdQuery(){Id = id});
        }

        [HttpPost]
        public async Task<decimal> Create([FromBody] CreateFinancialProductCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<FinancialProductDTO> Delete([FromRoute] decimal id)
        {
            return await Mediator.Send(new DeleteFinancialProductCommand() {Id = id});
        }
    }
}