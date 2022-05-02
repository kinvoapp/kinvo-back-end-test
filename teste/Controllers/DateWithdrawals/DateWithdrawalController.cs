using AutoMapper;
using Kinvo.Aliquota.Models.DateWithdrawals;
using Kinvo.Aliquota.Service.Interfaces.DateWithdrawals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Api.Console.Controllers.DateWithdrawals
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateWithdrawalController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IDateWithdrawalService _service;

        public DateWithdrawalController(ILogger<DateWithdrawalController> logger,
                                IMapper mapper,
                                IDateWithdrawalService service)
        {
            _logger = logger;
            _mapper = mapper;
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<DateWithdrawalResponse>))]
        public async Task<IActionResult> Post(DateWithdrawalRequest dateWithdrawalRequest)
        {

            var dateWithdrawal = await _service.Create(dateWithdrawalRequest);

            return Ok(dateWithdrawal);
        }

        [HttpPut("{uuid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<DateWithdrawalResponse>))]
        public async Task<IActionResult> Put(Guid? uuid, [FromBody] DateWithdrawalRequest dateWithdrawalRequest)
        {

            var dateWithdrawal = await _service.Edit(uuid, dateWithdrawalRequest);

            return Ok(dateWithdrawal);
        }

        [HttpDelete("{uuid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<DateWithdrawalResponse>))]
        public async Task<IActionResult> Delete(Guid? uuid)
        {
            await _service.Remove(uuid);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<DateWithdrawalResponse>))]
        public async Task<IActionResult> Get()
        {
            var response = await _service.List();

            return Ok(response);
        }
    }
}
