using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FundoInvestimentoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<FundoInvestimentoController> _logger;

        public FundoInvestimentoController(ILogger<FundoInvestimentoController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<FundoInvestimento> Get()
        //{
        //}
    }
}
