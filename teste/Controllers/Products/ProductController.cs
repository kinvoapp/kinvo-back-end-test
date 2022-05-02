using AutoMapper;
using Kinvo.Aliquota.Models.IncomeApplications;
using Kinvo.Aliquota.Models.Products;
using Kinvo.Aliquota.Service.Interfaces.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Api.Console.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public ProductController(ILogger<ProductController> logger,
                                IMapper mapper,
                                IProductService service)
        {
            _logger = logger;
            _mapper = mapper;
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<IncomeApplicationResponse>))]
        public async Task<IActionResult> Post(ProductRequest productRequest)
        {

            var product = await _service.Create(productRequest);

            return Ok(product);
        }

        [HttpPut("{uuid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<IncomeApplicationResponse>))]
        public async Task<IActionResult> Put(Guid? uuid, [FromBody] ProductRequest productRequest)
        {

            var product = await _service.Edit(uuid, productRequest);

            return Ok(product);
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
