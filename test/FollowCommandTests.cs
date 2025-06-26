namespace test;

using mb;

[TestClass]
public class FollowCommandTests
{
    [TestMethod]
    public void TestCommandConstructionRequiresAUserAndProjectName()
    {
        var command = new FollowCommand("user", "project");

        Assert.AreEqual("user", command.UserName);
        Assert.AreEqual("project", command.ProjectName);
    }

    [TestMethod]
    public void TestCommandExecutionAssociatesNewFollow()
    {
        var command = new FollowCommand("user", "project");

        var emptyFollows = new List<Dictionary<string, string>> { };
        var newFollows = command.Execute(emptyFollows);

        Assert.AreEqual("project", newFollows[0]["user"]);
    }

    [TestMethod]
    public void TestCommandExecutionDoesNotMaintainDuplicateFollows()
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