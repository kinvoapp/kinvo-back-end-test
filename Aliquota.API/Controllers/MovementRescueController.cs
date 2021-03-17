using System;
using Aliquota.Domain.DTO;
using Aliquota.Domain.Entities.Commercial;
using Aliquota.Domain.Entities.Financial;
using Aliquota.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Aliquota.Infra.CrossCutting;

namespace Aliquota.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementRescueController : ControllerBase
    {
        private IBaseService<MovementRescue> _baseMovementRescueService;

        public MovementRescueController(IBaseService<MovementRescue> baseMovementRescueService)
        {
            _baseMovementRescueService = baseMovementRescueService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] MovementRescueDTO movementRescueDTO)
        {
            if (movementRescueDTO is null)
            {
                throw new ArgumentNullException(nameof(movementRescueDTO));
            }

            if (movementRescueDTO == null)
                return NotFound();

            MovementRescue movementRescue = movementRescueDTO.ConvertMovementRescueDTOToMovementRescue();

            return Execute(() => _baseMovementRescueService.Add<Customer>(movementRescue).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] MovementRescueDTO movementRescueDTO)
        {
            if (movementRescueDTO == null)
                return NotFound();

            MovementRescue movementRescue = movementRescueDTO.ConvertMovementRescueDTOToMovementRescue();

            return Execute(() => _baseMovementRescueService.Update(movementRescue));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseMovementRescueService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseMovementRescueService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseMovementRescueService.GetById(id));
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

