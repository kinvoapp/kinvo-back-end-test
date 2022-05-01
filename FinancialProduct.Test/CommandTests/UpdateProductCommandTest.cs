using FinancialProduct.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinancialProduct.Test.CommandTests;

[TestClass]
public class UpdateProductCommandTest

{
    private readonly UpdateProductCommand _invalidCommand = new UpdateProductCommand(System.Guid.Empty,0);
    private readonly UpdateProductCommand _validCommand = new UpdateProductCommand(System.Guid.NewGuid(), 100);

    public UpdateProductCommandTest()
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