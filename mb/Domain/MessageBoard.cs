using System.Text;

namespace mb.Domain;

public class MessageBoard
{
    public List<Follow> Follows { get; set; } = [];
    public Dictionary<string, List<Message>> Messages { get; set; } = [];

    public string[]? Output { get; set; }

    public List<Message> TimeLineForProject(string projectName)
    {
        return [.. Messages[projectName].OrderBy(m => m.Timestamp)];
    }

    public List<WallLine> TimeLineForUser(string userName)
    {
        var wallLines = new List<WallLine>();
        
        var followedProjects = Follows.Where(f => f.UserName == userName).Select(f => f.ProjectName);
        
        foreach (var projectName in followedProjects)
        {
            if (Messages.ContainsKey(projectName))
            {
                foreach (var message in Messages[projectName])
                {
                    wallLines.Add(new WallLine(projectName, message));
                }
            }
        }
        
        return wallLines.OrderBy(wl => wl.Message.Timestamp).ToList();
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        foreach (var follow in Follows)
        {
            result.AppendLine(follow.ToString());
        }

        foreach (var project in Messages.Keys)
        {
            result.AppendLine(project);
            foreach (var message in Messages[project])
            {
                result.AppendLine(message.ToString());
            }
        }
        return result.ToString();
    }
}