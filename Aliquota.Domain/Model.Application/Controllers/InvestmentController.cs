using Microsoft.AspNetCore.Mvc;
using Model.Application.Models;
using Model.Domain.Entities;
using Model.Domain.Interfaces;
using Model.Infra.CrossCutting;
using Model.Service.Validators;
using System;

namespace Model.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private IBaseService<Investment> _baseInvestmentService;

        public InvestmentController(IBaseService<Investment> baseInvestmentService)
        {
            _baseInvestmentService = baseInvestmentService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateInvestmentModel Investment)
        {
            if (Investment == null)
                return NotFound();

            return Execute(() => _baseInvestmentService.Add<CreateInvestmentModel, InvestmentModel, InvestmentValidator>(Investment));
        }

        [HttpDelete]
        [Route("/api/Rescue")]
        public IActionResult Rescue([FromBody] Investment Investment)
        {
            if (Investment == null)
                return NotFound();

            Rescue r = new Rescue();
            double capital = Investment.Capital;
            DateTime investmentDayZero = Investment.InvestmentDayZero;
            double rescuedValue = r.rescue(capital, investmentDayZero);
            var incomeTax = Investment.Capital - rescuedValue;
            Delete(Investment.Id);
            return Ok("The rescued value was " + String.Format("{0:C}", Convert.ToInt32(rescuedValue)) + " and the incomeTax was " + String.Format("{0:C}", Convert.ToInt32(incomeTax)));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateInvestmentModel Investment)
        {
            if (Investment == null)
                return NotFound();

            return Execute(() => _baseInvestmentService.Update<UpdateInvestmentModel, InvestmentModel, InvestmentValidator>(Investment));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseInvestmentService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseInvestmentService.Get<InvestmentModel>());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseInvestmentService.GetById<InvestmentModel>(id));
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

