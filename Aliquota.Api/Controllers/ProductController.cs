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

        //Melhor para se testar no Postman
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repository) //injeção de dependencia... preciso do meu repositorio para retorno
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
            //localhost:5000/v1/clients
            /*
            Exemplo de uso... Método POST Body > RAW > Json 
            Corpo: {
                        "user":"KaoeFerreira",
                        "document":"01234567899" 
                    }
            */
            return (GenericCommandResult)handler.Handle(command);
        }
        [Route("products")]
        [HttpPost]
        public GenericCommandResult PostProduct([FromBody] CreateProductCommand command,
        [FromServices] CreateFlowCommandHandler handler)
        {
            //Cria o produto e retorna o valor da aliquota
            //localhost:5000/v1/clients/products
            //Exemplo de uso... Método POST Body > RAW > Json 
            /*
                {
                    "title":"OIBR3",
                    "price": 500,
                    "createDate":"2021-05-06", Formato da data YYYY-MM-DD
                    "rescueDate":"2022-09-03",
                    "user":"KaoeFerreira",
                    "document":"00000000000"
                }
            */
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("customers/{document}")]
        [HttpGet]
        public Client GetClient([FromServices] IProductRepository repository, string document)
        {
            // GET retorna o cliente
            //url 
            //localhost:5000/v1/clients/customers/01234567899 <---- CPF cadastrado 
            return repository.GetClient(document);
        }
        [Route("customers/products/{title}")]
        [HttpGet]
        public Product GetProducts([FromServices] IProductRepository repository, string title)
        {
            // GET retorna os produtos
            //url 
            //localhost:5000/v1/clients/customers/products/OIBR3 <----- Ativo cadastrado
            return repository.GetProduct(title);
        }
    }
}