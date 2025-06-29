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
}