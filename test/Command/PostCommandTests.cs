namespace test.Command;

using mb.Command;
using mb.Domain;
using Microsoft.VisualBasic;

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
        var projectName = "Bar";
        var command = new PostCommand("foo", projectName, "blech");

        var context = new MessageBoard();

        var updatedContext = command.Execute(context);

        Assert.AreEqual(1, updatedContext.Messages[projectName].Count);
    }

    [TestMethod]
    public void Command_Execution_Associates_Message_With_User_And_Existing_Project()
    {
        var projectName = "Bar";
        var command = new PostCommand("foo", projectName, "blech");

        var messages = new Dictionary<string, List<Message>>
        {
            [projectName] = [new Message("message")]
        };

        var context = new MessageBoard
        {
            Messages = messages
        };

        var updatedContext = command.Execute(context);

        Assert.AreEqual(2, updatedContext.Messages[projectName].Count);
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