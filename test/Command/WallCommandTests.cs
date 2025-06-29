namespace test.Command;

using mb.Command;
using mb.Domain;

[TestClass]
public class WallCommandTests
{
    [TestMethod]
    public void Command_Execution_Returns_Messages_For_Known_Project()
    {
        var command = new WallCommand("foo");

        var expectedMessages = new List<Message> { new("bar", "user"), new("blech", "user") };
        var messages = new Dictionary<string, List<Message>>
        {
            {"foo", expectedMessages},
        };

        var context = new MessageBoard
        {
            Messages = messages
        };

        var updatedContext = command.Execute(context);
        Assert.IsTrue(expectedMessages.SequenceEqual(updatedContext.Messages["foo"]));

    }

    [TestMethod]
    public void Command_Execution_Output_Are_User_Follows()
    {
        var user = "bar";
        var project = "foo";
        var command = new WallCommand(user);

        var userMessages = new List<Message> { new("blech", user) };
        var otherMessages = new List<Message> { new("otherMessage", "otherUser") };
        var messages = new Dictionary<string, List<Message>>
        {
            {project, userMessages},
            {"otherProject", otherMessages},
        };

        var context = new MessageBoard
        {
            Messages = messages,
            Follows = [new Follow(user, project)]
        };

        var updatedContext = command.Execute(context);
        Assert.AreEqual(1, updatedContext.Output.Length);
    }

    [TestMethod]
    public void Factory_Can_Build_Command_From_Input()
    {
        var command = WallCommand.FromInput("Charlie wall".Split());

        Assert.AreEqual("Charlie", ((WallCommand)command).UserName);

    }    
}