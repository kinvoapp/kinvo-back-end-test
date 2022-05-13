using AutoMapper;
using Kinvo.Aliquota.Domain.Entities.Clients;
using Kinvo.Aliquota.Models.Clients;
using Kinvo.Aliquota.Service.Interfaces.Clients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Api.Console.Controllers.Clients
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IClientService _service;

        public ClientController(ILogger<ClientController> logger,
                                IMapper mapper,
                                IClientService service)
        {
            _logger = logger;
            _mapper = mapper;
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ClientResponse>))]
        public async Task<IActionResult> Post(ClientRequest clientRequest)
        {

            var client = await _service.Create(clientRequest);

            return Ok(client);
        }

        [HttpPut("{uuid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ClientResponse>))]
        public async Task<IActionResult> Put(Guid? uuid, [FromBody] ClientRequest clientRequest)
        {

            var client = await _service.Edit(uuid, clientRequest);

            return Ok(client);
        }

        [HttpDelete("{uuid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ClientResponse>))]
        public async Task<IActionResult> Delete(Guid? uuid)
        {
            await _service.Remove(uuid);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ClientResponse>))]
        public async Task<IActionResult> Get()
        {
            var response = await _service.List();

            return Ok(response);
        }
    }
}
