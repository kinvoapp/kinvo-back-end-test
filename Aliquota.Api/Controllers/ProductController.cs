using System;
using System.Collections.Generic;
using System.Linq;
using Aliquota.Domain.Commands;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Handlers;
using Aliquota.Domain.Queries;
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
            //Cria o cliente
            return (GenericCommandResult)handler.Handle(command);
        }
        [Route("products")]
        [HttpPost]
        public GenericCommandResult PostProduct([FromBody] CreateProductCommand command,
        [FromServices] CreateFlowCommandHandler handler)
        {
            //Cria o produto
            return (GenericCommandResult)handler.Handle(command);
        }

        // [Route("products/order")]
        // [HttpPost]
        // public GenericCommandResult PostOrder([FromBody] AddOrderCommand command,
        // [FromServices] CreateFlowCommandHandler handler)
        // {
        //     // Adiciona a Ordem
        //     return (GenericCommandResult)handler.Handle(command);
        // }

        [Route("customers/{document}")]
        [HttpGet]
        public Client GetClient([FromServices] IProductRepository repository, string document)
        {
            // GET retorna o cliente
            return repository.GetClient(document);
        }
        [Route("customers/products/{title}")]
        [HttpGet]
        public Product GetProducts([FromServices] IProductRepository repository, string title)
        {
            // GET retorna os produtos
            return repository.GetProduct(title);
        }
        [Route("customers/products/orders/{userDocument}")]
        [HttpGet]
        public Order GetOrders([FromServices] IProductRepository repository, string userDocument)
        {
            // GET retorna os produtos
            //var product = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetOrder(userDocument);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult PutClient([FromBody] CreateClientCommand command,
        [FromServices] CreateFlowCommandHandler handler)
        {
            //PUT altera cliente
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}