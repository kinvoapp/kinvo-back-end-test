using AutoMapper;
using Kinvo.Aliquota.Models.IncomeApplications;
using Kinvo.Aliquota.Service.Interfaces.IncomeApplications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Api.Console.Controllers.IncomeApplications
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeApplicationController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IIncomeApplicationService _service;

        public IncomeApplicationController(ILogger<IncomeApplicationController> logger,
                                IMapper mapper,
                                IIncomeApplicationService service)
        {
            _logger = logger;
            _mapper = mapper;
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<IncomeApplicationResponse>))]
        public async Task<IActionResult> Post(IncomeApplicationRequest incomeApplicationRequest)
        {

            var incomeApplication = await _service.Create(incomeApplicationRequest);

            return Ok(incomeApplication);
        }

        [HttpPut("{uuid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<IncomeApplicationResponse>))]
        public async Task<IActionResult> Put(Guid? uuid, [FromBody] IncomeApplicationRequest incomeApplicationRequest)
        {

            var incomeApplication = await _service.Edit(uuid, incomeApplicationRequest);

            return Ok(incomeApplication);
        }

        [HttpDelete("{uuid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<IncomeApplicationResponse>))]
        public async Task<IActionResult> Delete(Guid? uuid)
        {
            await _service.Remove(uuid);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<IncomeApplicationResponse>))]
        public async Task<IActionResult> Get()
        {
            var response = await _service.List();

            return Ok(response);
        }
    }
}
