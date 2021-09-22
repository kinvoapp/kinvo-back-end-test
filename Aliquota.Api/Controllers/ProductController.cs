using System;
using System.Collections.Generic;
using System.Linq;
using Aliquota.Domain.Commands;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Handlers;
using Aliquota.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Aliquota.Api.Controller
{
    [ApiController]
    [Route("v1/clients")]

    public class ProductController : ControllerBase
    {
        //O Command é recebido pelo corpo da requisição por json
        //From services vem do Startup e nele passamos um handler 

        //Sem tomada de decisões em controller (ex: IF's)
        //Assim o controller fica muito mais enxuto 
        //Já que precisa passar por um command e ser manipulado por um handler
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repository)
        {
            _repo = repository;
        }
        [Route("")]
        [HttpPost]
        public GenericCommandResult PostClient([FromBody] CreateClientCommand command,
        [FromServices] CreateFlowCommandHandler handler)
        {
            //Toda escrita necessita de um handler
            return (GenericCommandResult)handler.Handle(command);
        }
        [Route("products/order")]
        [HttpPost]
        public GenericCommandResult PostOrder([FromBody] AddOrderCommand command,
        [FromServices] CreateFlowCommandHandler handler)
        {
            //Toda escrita necessita de um handler
            return (GenericCommandResult)handler.Handle(command);
        }
        [Route("products")]
        [HttpPost]
        public GenericCommandResult PostProduct([FromBody] CreateProductCommand command,
        [FromServices] CreateFlowCommandHandler handler)
        {
            //Toda escrita necessita de um handler
            return (GenericCommandResult)handler.Handle(command);
        }
        [Route("")]
        [HttpGet]
        public IEnumerable<Client> GetClient([FromServices] IProductRepository repository)
        {
            //Toda escrita necessita de um handler
            var documetnt = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetClient(documetnt);
        }
        [Route("products")]
        [HttpGet]
        public IEnumerable<Product> GetProducts([FromServices] IProductRepository repository)
        {
            //Toda escrita necessita de um handler
            var product = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetProduct(product);
        }
        [Route("aliquota")]
        [HttpGet]
        public Order GetIncomeTax([FromServices] IProductRepository repository)
        {
            //Toda escrita necessita de um handler
            var value = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.ReturnIncomeTax(5);
        }
        [Route("")]
        [HttpPut]
        public GenericCommandResult PutClient([FromBody] CreateClientCommand command,
        [FromServices] CreateFlowCommandHandler handler)
        {
            //Toda escrita necessita de um handler
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}