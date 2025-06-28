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

        var expectedMessages = new List<Message> { new("bar"), new("blech") };
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
    public void Command_Execution_Output_Are_User_Subscriptions()
    {
        var command = new WallCommand("foo");

        var expectedMessages = new List<Message> { new("bar"), new("blech") };
        var messages = new Dictionary<string, List<Message>>
        {
            {"foo", expectedMessages},
        };

        var context = new MessageBoard
        {
            Messages = messages
        };

        var updatedContext = command.Execute(context);
        Assert.IsNotNull(updatedContext.Output);
    }
    [TestMethod]
    public void Factory_Can_Build_Command_From_Input()
    {
        var command = WallCommand.FromInput("Charlie wall".Split());

        Assert.AreEqual("Charlie", ((WallCommand)command).UserName);

    }    
}