using System;
using System.Collections.Generic;
using Aliquota.Application.Dtos;
using Aliquota.Application.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.Api.Controllers
{
    [ApiController]
    [Route("controller")]
    public class FinancialApplicationController: ControllerBase
    {
        private readonly IApplicationServiceFinancialApplication applicationServiceFinancialApplication;

        public FinancialApplicationController(IApplicationServiceFinancialApplication applicationServiceFinancialApplication)
        {
            this.applicationServiceFinancialApplication = applicationServiceFinancialApplication;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(applicationServiceFinancialApplication.GetAll());
        }

        [HttpGet("id")]
        public ActionResult<string> Get(int id)
        {
            return Ok(applicationServiceFinancialApplication.GetById(id));
        }
        
       /* [HttpGet("id")]
        public ActionResult<string> GetROI(int id)
        {
            return Ok(applicationServiceFinancialApplication.GetById(id).GetROI());
        }
        */
        [HttpPost]
        public ActionResult Post([FromBody] FinancialApplicationDto financialApplicationDto)
        {
            try
            {
                if (financialApplicationDto == null)
                    return NotFound();
                applicationServiceFinancialApplication.Add(financialApplicationDto);
                return Ok("Aplicação Financeira cadastrada com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] FinancialApplicationDto financialApplicationDto)
        {
            try
            {
                if (financialApplicationDto == null)
                    return NotFound();
                applicationServiceFinancialApplication.Update(financialApplicationDto);
                return Ok("Aplicação Financeira atualizada com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] FinancialApplicationDto financialApplicationDto)
        {
            try
            {
                if (financialApplicationDto == null)
                    return NotFound();
                applicationServiceFinancialApplication.Remove(financialApplicationDto);
                return Ok("Aplicação Financeira removida com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}