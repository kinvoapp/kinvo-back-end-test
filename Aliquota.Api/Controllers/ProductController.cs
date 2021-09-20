using System.Collections.Generic;
using Aliquota.Domain.Commands;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Handlers;
using Aliquota.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.Api.Controller
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<Product> GetProducts([FromServices] IProductRepository repo)
        {
            return repo.GetProducts("ABCD4");
        }



        [Route("")]
        [HttpPost]
        //O Command é recebido pelo corpo da requisição por json
        //From services vem do Startup e nele passamos um handler 
        public GenericCommandResult Create([FromBody] CreateProductCommand command, [FromServices] ProductHandler handler)
        {
            //Sem tomada de decisões em controller (ex: IF's)
            //Assim o controller fica muito mais enxuto 
            //Já que precisa passar por um command e ser manipulado por um handler


            return (GenericCommandResult)handler.Handle(command);
        }

    }
}