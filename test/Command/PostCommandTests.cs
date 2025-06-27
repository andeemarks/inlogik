namespace test.Command;

using mb.Command;
using mb.Domain;

[TestClass]
public class PostCommandTests
{
    [TestMethod]
    public void Command_Construction_Requires_User_Name_Project_Name_And_Message()
    {
        var command = new PostCommand("foo", "bar", "blech");

        Assert.AreEqual("foo", command.UserName);
        Assert.AreEqual("bar", command.ProjectName);
        Assert.AreEqual("blech", command.Message);
    }

    [TestMethod]
    public void Command_Execution_Associates_Message_With_User_And_New_Project()
    {
        var command = new PostCommand("foo", "bar", "blech");

        var context = new MessageBoard();

        var updatedContext = command.Execute(context);

        Assert.AreEqual(1, updatedContext.Messages["bar"].Count);
    }

    [TestMethod]
    public void Factory_Can_Build_Command_From_Input()
    {
        var command = PostCommand.FromInput("Alice -> @Moonshot I'm working on the log on screen".Split());

        Assert.AreEqual("Alice", ((PostCommand)command).UserName);
        Assert.AreEqual("Moonshot", ((PostCommand)command).ProjectName);
        Assert.AreEqual("I'm working on the log on screen", ((PostCommand)command).Message);

    }
}