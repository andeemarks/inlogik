namespace test.Display;

using mb.Command;
using mb.Domain;
using mb.Display;

[TestClass]
public class ReadResultTests
{
    [TestMethod]
    public void Result_Contains_Messages_For_Project_Ordered_By_User()
    {
        var timeStamp = DateTime.Now;

        var messages = new Dictionary<string, List<Message>>
        {
            ["project"] = [new Message("second", "user1", timeStamp), new Message("third", "user2", timeStamp.AddSeconds(1)), new Message("first", "user1", timeStamp.AddSeconds(-1))]
        };
        var context = new MessageBoard
        {
            Messages = messages
        };

        var result = ReadResult.For(context, new ReadCommand("project"));

        Assert.AreEqual("user1", result[0]);
        Assert.AreEqual("first (just now)", result[1]);
        Assert.AreEqual("second (just now)", result[2]);
        Assert.AreEqual("user2", result[3]);
        Assert.AreEqual("third (just now)", result[4]);
    }

    [TestMethod]
    public void Result_Empty_For_Unknown_Project()
    {
        var context = new MessageBoard
        {
            Messages = []
        };

        var result = ReadResult.For(context, new ReadCommand("project"));

        Assert.AreEqual(0, result.Length);
    }

}