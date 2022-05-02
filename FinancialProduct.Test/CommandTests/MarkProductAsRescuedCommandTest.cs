using FinancialProduct.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinancialProduct.Test.CommandTests;

[TestClass]
public class MarkProductAsRescuedCommandTest
{
    private readonly MarkProductAsRescuedCommand _invalidCommand = new MarkProductAsRescuedCommand(System.Guid.Empty,"");
    private readonly MarkProductAsRescuedCommand _validCommand = new MarkProductAsRescuedCommand(System.Guid.NewGuid(),"BruceWayne");

    public MarkProductAsRescuedCommandTest()
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