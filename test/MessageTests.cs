namespace test;

using mb;
using mb.Domain;

[TestClass]
public class MessageTests
{
    [TestMethod]
    public void Message_Timestamps_Creation()
    {
        var message = new Message("foo");

        Assert.IsNotNull(message.Timestamp);
    }
}