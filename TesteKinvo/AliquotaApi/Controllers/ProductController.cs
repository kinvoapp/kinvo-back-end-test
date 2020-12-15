using System;
using System.Collections.Generic;
using Aliquota.Application.Dtos;
using Aliquota.Application.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.Api.Controllers
{
    [ApiController]
    [Route("v1/Products")]
    public class ProductController : ControllerBase
    {
        private readonly IApplicationServiceProduct applicationServiceProduct;

        public ProductController(IApplicationServiceProduct applicationServiceProduct)
        {
            this.applicationServiceProduct = applicationServiceProduct;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(applicationServiceProduct.GetAll());
        }
        [HttpGet("id")]
        public ActionResult<string> Get(int id)
        {
            return Ok(applicationServiceProduct.GetById(id));
        }
        [HttpPost]
        public ActionResult Post([FromBody] ProductDto productDto)
        {
            try
            {
                if (productDto == null)
                    return NotFound();
                applicationServiceProduct.Add(productDto);
                return Ok("Produto Cadastrado com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] ProductDto productDto)
        {
            try
            {
                if (productDto == null)
                    return NotFound();
                applicationServiceProduct.Update(productDto);
                return Ok("Produto atualizado com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] ProductDto productDto)
        {
            try
            {
                if (productDto == null)
                    return NotFound();
                applicationServiceProduct.Remove(productDto);
                return Ok("Produto removido com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}