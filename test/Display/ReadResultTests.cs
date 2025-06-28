namespace test.Display;

using mb.Command;
using mb.Domain;
using mb.Display;

[TestClass]
public class ReadResultTests
{
    [TestMethod]
    public void Result_Contains_Ordered_Messages_For_Project()
    {
        var messages = new Dictionary<string, List<Message>>
        {
            ["project"] = [new Message("first"), new Message("second"), new Message("third")]
        };
        var context = new MessageBoard
        {
            Messages = messages
        };

        var result = ReadResult.For(context, new ReadCommand("project"));

        Assert.AreEqual("project", result[0]);
        Assert.IsTrue(result[1].StartsWith("first"));
        Assert.IsTrue(result[2].StartsWith("second"));
        Assert.IsTrue(result[3].StartsWith("third"));
    }

}