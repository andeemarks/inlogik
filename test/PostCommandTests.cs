namespace test;

using mb.Command;

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

}