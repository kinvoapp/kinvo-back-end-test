using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Domain.DTO;
using Aliquota.Domain.Entities.Commercial;
using Aliquota.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IBaseService<Customer> _baseCustomerService;

        public CustomerController(IBaseService<Customer> baseCustomerService)
        {
            _baseCustomerService = baseCustomerService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CustomerDTO customerDTO)
        {
            if (customerDTO is null)
            {
                throw new ArgumentNullException(nameof(customerDTO));
            }

            if (customerDTO == null)
                return NotFound();

            Customer customer = customerDTO.ConvertCustomerDTOToCustumer();

            return Execute(() => _baseCustomerService.Add<Customer>(customer).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] CustomerDTO customerDTO)
        {
            if (customerDTO == null)
                return NotFound();

            Customer customer = customerDTO.ConvertCustomerDTOToCustumer();

            return Execute(() => _baseCustomerService.Update(customer));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseCustomerService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseCustomerService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseCustomerService.GetById(id));
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

