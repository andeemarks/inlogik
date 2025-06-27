namespace test;

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

}