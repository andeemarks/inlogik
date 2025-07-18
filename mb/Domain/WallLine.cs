namespace mb.Domain;

public class WallLine
{
    public WallLine(string projectName, Message message)
    {
        ProjectName = projectName;
        Message = message;
    }

    public string ProjectName { get; }
    public Message Message { get; }

    public override bool Equals(object? obj)
    {
        if (obj is WallLine other)
        {
            return ProjectName == other.ProjectName && Message.Equals(other.Message);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ProjectName, Message);
    }
}
