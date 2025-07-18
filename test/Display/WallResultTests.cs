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
        var timeStamp = DateTime.Now;

        var messages = new Dictionary<string, List<Message>>
        {
            ["project1"] = [new Message("second", "user1", timeStamp),
                            new Message("third", "user2", timeStamp.AddSeconds(1))],
            ["project2"] = [new Message("foo", "user3", timeStamp.AddSeconds(3)),
                            new Message("bar", "user3", timeStamp.AddSeconds(-2))],
            ["project3"] = [new Message("second", "user1", timeStamp.AddSeconds(3)),
                            new Message("first", "user1", timeStamp.AddSeconds(-2))]
        };

        var context = new MessageBoard
        {
            Messages = messages,
            Follows = [new Follow("user1", "project1"), new Follow("user1", "project3")]
        };

        var result = WallResult.For(context, new WallCommand("user1"));

        Assert.AreEqual("project3 - user1: first (just now)", result[0]);
        Assert.AreEqual("project1 - user1: second (just now)", result[1]);
        Assert.AreEqual("project1 - user2: third (just now)", result[2]);
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