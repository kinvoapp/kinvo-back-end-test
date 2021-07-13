using Aliquota.Domain.Exceptions;
using Aliquota.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aliquota.WebApp.Filters
{
    public class DomainExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is HandlerException)
            {
                context.Result = new OkObjectResult(new RequestResult<object>{
                    Success = false,
                    Message = context.Exception.Message,
                });
            }
        }
    }
}