namespace mb.Domain;

public class Message(string text = "")
{
    public string Text { get; } = text;
    public DateTime Timestamp { get; } = DateTime.Now;

    private string CreatedOn()
    {
        return CreatedOn(DateTime.Now);
    }
    public string CreatedOn(DateTime currentTime)
    {
        TimeSpan timeSinceCreation = currentTime.Subtract(Timestamp);

        if (timeSinceCreation.TotalMinutes < 1)
        {
            return "just now";
        }
        else if (timeSinceCreation.TotalMinutes < 2)
        {
            return "1 minute ago";
        }
        else
        {
            return $"{timeSinceCreation.TotalMinutes:F0} minutes ago";
        }
    }

    public override string ToString()
    {
        return $"{Text} ({CreatedOn()})";
    }

}