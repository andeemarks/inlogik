namespace test.Command;

using mb.Command;
using mb.Domain;

[TestClass]
public class FollowCommandTests
{
    [TestMethod]
    public void Command_Construction_Requires_User_And_Project_Name()
    {
        var command = new FollowCommand("user", "project");

        Assert.AreEqual("user", command.UserName);
        Assert.AreEqual("project", command.ProjectName);
    }

    [TestMethod]
    public void Command_Execution_Associates_New_Follow()
    {
        var command = new FollowCommand("user", "project");

        var context = new MessageBoard();

        var newFollows = command.Execute(context);

        Assert.AreEqual("project", newFollows[0].ProjectName);
    }

    [Ignore]
    [TestMethod]
    public void Command_Execution_Does_Not_Maintain_Duplicate_Follows()
    {
        var command = new FollowCommand("user", "project");

        var initialFollows = new List<Follow>
        {
            new("user", "project")
        };

        var context = new MessageBoard
        {
            Follows = initialFollows
        };
        var newFollows = command.Execute(context);

        Assert.AreEqual(1, newFollows.Count);
    }

    [TestMethod]
    public void Factory_Can_Build_Command_From_Input()
    {
        var command = FollowCommand.FromInput("Charlie follows Apollo".Split());

        Assert.AreEqual("Charlie", command.UserName);
        Assert.AreEqual("Apollo", command.ProjectName);

    }
}