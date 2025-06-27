namespace test.Command;

using mb.Command;
using mb.Domain;

[TestClass]
public class WallCommandTests
{
    [TestMethod]
    public void Factory_Can_Build_Command_From_Input()
    {
        var command = WallCommand.FromInput("Charlie wall".Split());

        Assert.AreEqual("Charlie", ((WallCommand)command).UserName);

    }    
}