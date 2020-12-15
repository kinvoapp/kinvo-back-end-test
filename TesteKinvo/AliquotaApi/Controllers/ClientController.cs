using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Application.Dtos;
using Aliquota.Application.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.Api.Controllers
{
    [ApiController]
    [Route("v1/Clients")]
    public class ClientController : ControllerBase
    {
        private readonly IApplicationServiceClient applicationServiceClient;

        public ClientController(IApplicationServiceClient applicationServiceClient)
        {
            this.applicationServiceClient = applicationServiceClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(applicationServiceClient.GetAll());
        }

        [HttpGet("id")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                return Ok(applicationServiceClient.GetById(id));
            }
            catch (Exception ex)
            {

                return ("Ocorreram problemas, tente mais tarde");
            }
           
        }

        [HttpPost]
        public ActionResult Post([FromBody] ClientDto clientDto)
        {
            try
            {
                if (clientDto == null)
                    return NotFound();
                applicationServiceClient.Add(clientDto);
                return Ok("Cliente Cadastrado com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] ClientDto clientDto)
        {
            try
            {
                if (clientDto == null)
                    return NotFound();
                applicationServiceClient.Update(clientDto);
                return Ok("Cliente atualizado com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] ClientDto clientDto)
        {
            try
            {
                if (clientDto == null)
                    return NotFound();
                applicationServiceClient.Remove(clientDto);
                return Ok("Cliente removido com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}