using AutoMapper;
using Kinvo.Aliquota.Models.DateIncomeApplications;
using Kinvo.Aliquota.Service.Interfaces.DateIncomeApplications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Api.Console.Controllers.DateIncomeApplications
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateIncomeApplicationController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IDateIncomeApplicationService _service;

        public DateIncomeApplicationController(ILogger<DateIncomeApplicationController> logger,
                                IMapper mapper,
                                IDateIncomeApplicationService service)
        {
            _logger = logger;
            _mapper = mapper;
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<DateIncomeApplicationResponse>))]
        public async Task<IActionResult> Post(DateIncomeApplicationRequest dateIncomeApplicationRequest)
        {

            var dateIncomeApplication = await _service.Create(dateIncomeApplicationRequest);

            return Ok(dateIncomeApplication);
        }

        [HttpPut("{uuid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<DateIncomeApplicationResponse>))]
        public async Task<IActionResult> Put(Guid? uuid, [FromBody] DateIncomeApplicationRequest cdateIncomeApplicationRequest)
        {

            var dateIncomeApplication = await _service.Edit(uuid, cdateIncomeApplicationRequest);

            return Ok(dateIncomeApplication);
        }

        [HttpDelete("{uuid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<DateIncomeApplicationResponse>))]
        public async Task<IActionResult> Delete(Guid? uuid)
        {
            await _service.Remove(uuid);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<DateIncomeApplicationResponse>))]
        public async Task<IActionResult> Get()
        {
            var response = await _service.List();

            return Ok(response);
        }
    }
}
