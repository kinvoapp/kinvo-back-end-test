using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Domain.DTO;
using Aliquota.Domain.Entities.Commercial;
using Aliquota.Domain.Interfaces;
using Aliquota.Infra.CrossCutting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerProductController : ControllerBase
    {
        private IBaseService<CustomerProduct> _baseCustomerProductService;

        public CustomerProductController(IBaseService<CustomerProduct> baseCustomerProductService)
        {
            _baseCustomerProductService = baseCustomerProductService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CustomerProductDTO customerProductDTO)
        {
            if (customerProductDTO is null)
            {
                throw new ArgumentNullException(nameof(customerProductDTO));
            }

            if (customerProductDTO is null)
            {
                throw new ArgumentNullException(nameof(customerProductDTO));
            }

            if (customerProductDTO == null)
                return NotFound();

            CustomerProduct customerProduct = customerProductDTO.ConvertCustomerProductDTOToCustomerProduct();

            return Execute(() => _baseCustomerProductService.Add<CustomerProduct>(customerProduct).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] CustomerProductDTO customerProductDTO)
        {
            if (customerProductDTO == null)
                return NotFound();

            CustomerProduct customerProduct = customerProductDTO.ConvertCustomerProductDTOToCustomerProduct();

            return Execute(() => _baseCustomerProductService.Update(customerProduct));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseCustomerProductService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseCustomerProductService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseCustomerProductService.GetById(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

