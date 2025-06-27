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

}

