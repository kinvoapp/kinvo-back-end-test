using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.API.Models.Response;
using Aliquota.Core.DTO;
using Aliquota.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aliquota.API.Controllers
{
    [ApiController]
    [Route("api/Application")]
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger<ApplicationController> logger;
        private readonly IApplicationService service;

        public ApplicationController(ILogger<ApplicationController> logger, IApplicationService service)
        {
            this.logger = logger;
            this.service = service;
        }

        /// <summary>
        /// Withdraw an share value, gettin back the value after taxes are paid
        /// </summary>
        /// <parameter name="fantasyName">fantasy name to search the application</parameter>
        /// <returns>WithDrawApplicationResponse object</returns>
        /// <response code="200">Success</response>
        /// <response code="204">No Content</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>

        [HttpPut]
        public ActionResult Put(string fantasyName)
        {
            WithDrawApplicationDto shareWithdraw = service.WithDrawShareApplication(fantasyName);
            return shareWithdraw != null ? Ok((WithDrawApplicationResponse)shareWithdraw) : NoContent();
        }

        /// <summary>
        /// Create a new Application
        /// </summary>
        /// <parameter name="request">CreateApplicationRequest object</parameter>
        /// <response code="204">No Content</response>
        /// <response code="500">Due to server problems, it`s not possible to get your data now</response>
        [HttpPost]
        public ActionResult Post(CreateApplicationRequest request)
        {
            service.Create(request.Value, request.FantasyName);
            return NoContent();
        }

    }
}
