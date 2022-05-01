using FinancialProduct.Domain.Commands;
using FinancialProduct.Domain.Entities;
using FinancialProduct.Domain.Handlers;
using FinancialProduct.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Form.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    [HttpGet("/{user}")]
    public IEnumerable<Product> GetAllByUser(
        [FromRoute] string user,
        [FromServices] IProductRepository repository )
    {
        return repository.GetAllQuery(user);
    }


    [HttpPost("")]
    public CommandResult Create(
        [FromBody] CreateProductCommand command,
        [FromServices] ProductHandler handler )
    {
        return (CommandResult)handler.Handle(command);
    }

    [HttpPut("")]
    public CommandResult Update(
      [FromBody] UpdateProductCommand command,
      [FromServices] ProductHandler handler )
    {
        return (CommandResult)handler.Handle(command);
    }

    [HttpPut("/rescued")]
    public CommandResult Rescued(
      [FromBody] MarkProductAsRescuedCommand command,
      [FromServices] ProductHandler handler  )
    {
        return (CommandResult)handler.Handle(command);
    }

}