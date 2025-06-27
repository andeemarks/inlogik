namespace test;

using mb;
using mb.Command;

[TestClass]
public class InputParserTests
{
    [TestMethod]
    public void Parser_Recognizes_A_Read_Command()
    {
        var command = InputParser.Parse("Moonshot");

        Assert.IsInstanceOfType(command, typeof(ICommand));
        Assert.AreEqual("Moonshot", ((ReadCommand)command).ProjectName);
    }

    [TestMethod]
    public void Parser_Recognizes_A_Follow_Command()
    {
        var command = InputParser.Parse("Charlie follows Apollo");

        Assert.IsInstanceOfType(command, typeof(ICommand));
        Assert.AreEqual("Charlie", ((FollowCommand)command).UserName);
        Assert.AreEqual("Apollo", ((FollowCommand)command).ProjectName);
    }

}

