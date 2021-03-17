using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Domain.DTO;
using Aliquota.Domain.Entities.Commercial;
using Aliquota.Domain.Entities.Financial;
using Aliquota.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aliquota.Infra.CrossCutting;

namespace Aliquota.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementApplicationController : ControllerBase
    {
        private IBaseService<MovementApplication> _baseMovementApplicationService;

        public MovementApplicationController(IBaseService<MovementApplication> baseMovementApplicationService)
        {
            _baseMovementApplicationService = baseMovementApplicationService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] MovementApplicationDTO movementApplicationDTO)
        {
            if (movementApplicationDTO is null)
            {
                throw new ArgumentNullException(nameof(movementApplicationDTO));
            }

            if (movementApplicationDTO == null)
                return NotFound();

            MovementApplication movementApplication = movementApplicationDTO.ConvertMovementApplicationDTOToMovementApplication();

            return Execute(() => _baseMovementApplicationService.Add<Customer>(movementApplication).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] MovementApplicationDTO movementApplicationDTO)
        {
            if (movementApplicationDTO == null)
                return NotFound();

            MovementApplication customer = movementApplicationDTO.ConvertMovementApplicationDTOToMovementApplication();

            return Execute(() => _baseMovementApplicationService.Update(customer));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseMovementApplicationService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseMovementApplicationService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseMovementApplicationService.GetById(id));
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

