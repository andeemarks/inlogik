namespace mb.Domain;

public class Message(string text="")
{
    public string Text { get; } = text;
    public DateTime Timestamp { get; } = DateTime.Now;
}