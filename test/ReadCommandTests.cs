namespace test;

using mb;

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

        var messages = new Dictionary<string, List<string>>
        {

        };

        var projectMessages = command.Execute(messages);
        Assert.IsNotNull(projectMessages);
        Assert.AreEqual(0, projectMessages.Count);
        
    }

    [TestMethod]
    public void Command_Execution_Returns_Messages_For_Known_Project()
    {
        var command = new ReadCommand("foo");

        var expectedMessages = new List<string> { "bar", "blech" };
        var messages = new Dictionary<string, List<string>>
        {
            {"foo", expectedMessages},
        };

        var projectMessages = command.Execute(messages);
        Assert.IsTrue(expectedMessages.SequenceEqual(projectMessages));
        
    }
}