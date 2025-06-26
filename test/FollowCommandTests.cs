namespace test;

using mb.Command;

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

        var emptyFollows = new List<Dictionary<string, string>> { };
        var newFollows = command.Execute(emptyFollows);

        Assert.AreEqual("project", newFollows[0]["user"]);
    }

    [Ignore]
    [TestMethod]
    public void Command_Execution_Does_Not_Maintain_Duplicate_Follows()
    {
        var command = new FollowCommand("user", "project");

        var initialFollows = new List<Dictionary<string, string>>
        {
            new() { { "user", "project" } }
        };

        var newFollows = command.Execute(initialFollows);

        Assert.AreEqual(1, newFollows.Count);
    }
}