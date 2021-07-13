using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Aliquota.API.Handlers
{
    [ExcludeFromCodeCoverage]
    public class ExceptionHandlingMiddleware : ControllerBase
    {
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Get(
            [FromServices] IWebHostEnvironment env
        )
        {
            if (env.EnvironmentName != "Development")
            {
                return Problem();
            }

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;

            if (exception.GetType().Name == "BusinessException")
            {
                if (exception.Message.Contains("not found"))
                {
                    return Problem(
                    title: exception.Message,
                    type: exception.GetType().Name,
                    statusCode: 404
                );
                }
                return Problem(
                    title: exception.Message,
                    type: exception.GetType().Name,
                    statusCode: 500
                );
            }
            
            return Problem(
                //detail: exception.StackTrace,
                title: exception.Message,
                type: exception.GetType().Name
            );
        }
    }
}