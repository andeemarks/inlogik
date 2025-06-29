namespace test.Display;

using mb.Command;
using mb.Domain;
using mb.Display;

[TestClass]
public class WallResultTests
{
    [TestMethod]
    public void Result_Contains_Ordered_Messages_For_User_Follows()
    {
        var messages = new Dictionary<string, List<Message>>
        {
            ["project"] = [new Message("first", "user"), new Message("second", "user"), new Message("third", "user")]
        };

        var context = new MessageBoard
        {
            Messages = messages,
            Follows = [new Follow("user", "project")]
        };

        var result = WallResult.For(context, new WallCommand("user"));

        Assert.IsTrue(result[0].StartsWith("project - first"));
        Assert.IsTrue(result[1].StartsWith("project - second"));
        Assert.IsTrue(result[2].StartsWith("project - third"));
    }

    [TestMethod]
    public void Result_Empty_For_User_Without_Follows()
    {
        var context = new MessageBoard
        {
            Messages = []
        };

        var result = WallResult.For(context, new WallCommand("user"));

        Assert.AreEqual(0, result.Length);
    }

}