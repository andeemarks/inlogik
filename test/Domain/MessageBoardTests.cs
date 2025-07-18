namespace test.Domain;

using mb.Domain;

[TestClass]
public class MessageBoardTests
{
    [TestMethod]
    public void Message_Board_Holds_All_Components()
    {
        var board = new MessageBoard();

        Assert.IsNotNull(board.Follows);
        Assert.IsNotNull(board.Messages);
    }

    [TestMethod]
    public void Message_Board_Can_Order_Messages_For_A_Project()
    {
        var timeStamp = DateTime.Now;

        var messages = new Dictionary<string, List<Message>>
        {
            ["project"] = [new Message("second", "user1", timeStamp), new Message("third", "user2", timeStamp.AddMinutes(1)), new Message("first", "user1", timeStamp.AddMinutes(-1))]
        };
        var board = new MessageBoard
        {
            Messages = messages
        };

        var timeline = board.TimeLineForProject("project");

        Assert.AreEqual("first", timeline[0].Text);
        Assert.AreEqual("second", timeline[1].Text);
        Assert.AreEqual("third", timeline[2].Text);

    }

    [TestMethod]
    public void Message_Board_Can_Order_Messages_For_A_User_Follows()
    {
        var timeStamp = DateTime.Now;

        var messages = new Dictionary<string, List<Message>>
        {
            ["project1"] = [new Message("second", "user1", timeStamp),
                            new Message("third", "user2", timeStamp.AddSeconds(1))],
            ["project2"] = [new Message("foo", "user3", timeStamp.AddSeconds(3)),
                            new Message("bar", "user3", timeStamp.AddSeconds(-2))],
            ["project3"] = [new Message("fourth", "user1", timeStamp.AddSeconds(3)),
                            new Message("first", "user1", timeStamp.AddSeconds(-2))]
        };

        var board = new MessageBoard
        {
            Messages = messages,
            Follows = [new Follow("user1", "project1"), new Follow("user1", "project3")]
        };

        var timeline = board.TimeLineForUser("user1");

        Assert.AreEqual(new WallLine("project3", new Message("first", "user1", timeStamp.AddSeconds(-2))), timeline[0]);
        Assert.AreEqual(new WallLine("project1", new Message("second", "user1", timeStamp)), timeline[1]);
        Assert.AreEqual(new WallLine("project1", new Message("third", "user2", timeStamp.AddSeconds(1))), timeline[2]);
        Assert.AreEqual(new WallLine("project3", new Message("fourth", "user1", timeStamp.AddSeconds(3))), timeline[3]);

    }
}