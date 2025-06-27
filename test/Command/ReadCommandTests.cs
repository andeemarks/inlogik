namespace test.Command;

using mb.Command;
using mb.Domain;

[TestClass]
public class ReadCommandTests
{
    [TestMethod]
    public void Command_Construction_Requires_Project_Name()
    {
        var command = new ReadCommand("foo");

        Assert.AreEqual("foo", command.ProjectName);
    }

    [TestMethod]
    public void Command_Execution_Returns_Empty_List_For_Unknown_Project()
    {
        var command = new ReadCommand("foo");

        var messages = new Dictionary<string, List<Message>>
        {

        };

        var context = new MessageBoard
        {
            Messages = messages
        };

        var projectMessages = command.Execute(context);
        Assert.IsNotNull(projectMessages);
        Assert.AreEqual(0, projectMessages.Count);

    }

    [TestMethod]
    public void Command_Execution_Returns_Messages_For_Known_Project()
    {
        var command = new ReadCommand("foo");

        var expectedMessages = new List<Message> { new("bar"), new("blech") };
        var messages = new Dictionary<string, List<Message>>
        {
            {"foo", expectedMessages},
        };

        var context = new MessageBoard
        {
            Messages = messages
        };

        var projectMessages = command.Execute(context);
        Assert.IsTrue(expectedMessages.SequenceEqual(projectMessages));

    }

    [TestMethod]
    public void Factory_Can_Build_Command_From_Input()
    {
        var command = ReadCommand.FromInput("Moonshot".Split());

        Assert.AreEqual("Moonshot", command.ProjectName);

    }    
}