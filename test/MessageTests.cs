namespace test;

using mb.Domain;

[TestClass]
public class MessageTests
{
    [TestMethod]
    public void Message_Timestamps_Creation()
    {
        var message = new Message("foo");

        Assert.IsInstanceOfType(message.Timestamp, typeof(DateTime));
    }

    [TestMethod]
    public void Message_Timestamps_Are_Displayed_As_Minutes()
    {
        var message = new Message("foo");

        Assert.AreEqual("just now", message.CreatedOn());
    }
}