using FinancialProduct.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinancialProduct.Test.CommandTests;

[TestClass]
public class CreateProductCommandTest
{
    private readonly CreateProductCommand _invalidCommand = new CreateProductCommand("", 0 ,"");
    private readonly CreateProductCommand _validCommand = new CreateProductCommand("Títulos públicos", 100,"Bruce Wayne");

    public CreateProductCommandTest()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
    }

    [TestMethod]
    public void Given_a_invalid_command_should_return_false()
    {
        Assert.AreEqual(_invalidCommand.Valid, false);
    }

    [TestMethod]
    public void Given_a_valid_command_should_return_true()
    {
        Assert.AreEqual(_validCommand.Valid, true);
    }
}