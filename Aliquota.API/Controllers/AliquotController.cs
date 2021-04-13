using Aliquota.API.Models.Request;
using Aliquota.API.Models.Response;
using Aliquota.Domain.DTO;
using Aliquota.Domain.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Aliquot.API.Controllers
{
    /// <summary>
    /// Aliquot Controller
    /// </summary>    
    [ApiController]
    [Route("api/aliquot")]
    public class AliquotController : ControllerBase
    {
        private readonly IApplicationService ApplicationService;
        private readonly IClientService ClientService;

        public AliquotController(IApplicationService appService, IClientService cliService)
        {
            
            ApplicationService = appService;
            ClientService =cliService;
        }


        /// <summary>
        /// Creates a client in the database
        /// </summary>
        /// <parameter name="request">CreateClientRequest object</parameter>
        /// <response code="204">Client successfully created</response>
        /// <response code="400">Client name already exists</response>
        /// <response code="500">Internal error</response>
        [HttpPost("create")]
        public ActionResult Create([FromBody]CreateClientRequest request)
        {
            ClientDTO clientExist = ClientService.GetByCPF(request.CPF);
            if(clientExist.CPF == request.CPF) return BadRequest();

            ClientDTO client = new ClientDTO() { CPF = request.CPF };
            ClientService.Create(client);
            return NoContent();
        }

        /// <summary>
        /// Perform an application
        /// </summary>
        /// <parameter name="request">ApplyRequest object</parameter>
        /// <response code="200">Successful application</response>
        /// <response code="400">Application value invalid</response>
        /// <response code="500">Internal error</response>
        [HttpPost("apply")]
        public ActionResult Apply([FromBody]ApplyRequest request)
        {
            if(request.ApplicationValue <= 0) return BadRequest();

            ClientDTO client = ClientService.GetByCPF(request.ClientCPF);
            ApplicationDTO response = (ApplicationDTO)ApplicationService.Apply(request.ApplicationValue, client.ClientId);
            return Ok((ApplyResponse)response);
        }

        /// <summary>
        /// Perform an application
        /// </summary>
        /// <parameter name="applicationCode">Application identifier code</parameter>
        /// <response code="200">Successful withdraw</response>
        /// <response code="400">This withdrawal has already been carried out</response>
        /// <response code="500">Internal error</response>
        [HttpPatch("withdraw")]
        public ActionResult Withdraw(string applicationCode)
        {
            ApplicationDTO application = ApplicationService.GetByCode(applicationCode);

            if(application.WithdrawDate < application.ApplicationDate || application.WithdrawDate != null) return BadRequest();
            ApplicationDTO response = ApplicationService.Withdraw(application);
            return Ok((WithdrawResponse)response);
        }
    }
}
