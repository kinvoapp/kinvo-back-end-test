using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.API.Controllers
{
    public class Controller : ControllerBase
    {
        protected IActionResult CustomResponse(object response = null, bool error = false)
        {
            var errorMessages = GetErrorMessages();

            if(errorMessages?.Any() == true)
            {
                return BadRequest(errorMessages);
            }

            if(error)
            {
                if(response == null)
                {
                    return BadRequest();
                }

                return BadRequest(response);
            }

            if(response == null)
            {
                return Ok();
            }

            return Ok(response);
        }

        private List<string> GetErrorMessages()
        {
            if (!ModelState.IsValid)
            {
                return ModelState.Values.SelectMany(e => e.Errors.Select(e => e.ErrorMessage)).ToList();
            }

            return null;
        }
    }
}