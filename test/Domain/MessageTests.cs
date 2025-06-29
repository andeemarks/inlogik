namespace test.Domain;

using mb.Domain;

[TestClass]
public class MessageTests
{
    [TestMethod]
    public void Message_Timestamps_Creation()
    {
        var message = new Message("foo", "user");

        Assert.IsInstanceOfType(message.Timestamp, typeof(DateTime));
    }

    [TestMethod]
    public void Message_Timestamps_Are_Displayed_As_Minutes()
    {
        var message = new Message("foo", "user");

        var now = DateTime.Now;

        Assert.AreEqual("just now", message.CreatedOn(now.AddMinutes(0)));
        Assert.AreEqual("1 minute ago", message.CreatedOn(now.AddMinutes(1)));
        Assert.AreEqual("2 minutes ago", message.CreatedOn(now.AddMinutes(2)));
        Assert.AreEqual("56 minutes ago", message.CreatedOn(now.AddMinutes(56)));
    }
}