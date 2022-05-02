using System;
using FinancialProduct.Domain.Commands;
using FinancialProduct.Domain.Handlers;
using FinancialProduct.Test.RepositoryTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace FinancialProduct.Test.HandlerTests;

[TestClass]
public class ProductHandlerTest
{
    private readonly CreateProductCommand _invalidCommand = new CreateProductCommand("", 0, "");

    private readonly ProductHandler _handler = new ProductHandler(new FakeProductRepository());
    private CommandResult _result = new CommandResult();

    public ProductHandlerTest()
    {

    }
    
    [TestMethod]
    public void Given_a_invalid_command_should_return_false()
    {
        _result = (CommandResult)_handler.Handle(_invalidCommand);
        Assert.AreEqual(_result.Success, false);
    }

  
}
