namespace mb.Domain;

public class Message(string text, string userName, DateTime? timeStamp = null)
{
    public string Text { get; } = text;
    public string UserName { get; } = userName;
    public DateTime? Timestamp { get; } = timeStamp == null ? DateTime.Now : timeStamp;

    private string CreatedOn()
    {
        return CreatedOn(DateTime.Now);
    }
    public string CreatedOn(DateTime currentTime)
    {
        TimeSpan timeSinceCreation = currentTime.Subtract(Timestamp ?? DateTime.Now);

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

    public override bool Equals(object? obj)
    {
        if (obj is Message other)
        {
            return Text == other.Text && UserName == other.UserName && Timestamp == other.Timestamp;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Text, UserName, Timestamp);
    }
}