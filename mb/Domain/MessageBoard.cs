using System.Text;

namespace mb.Domain;

public class MessageBoard
{
    public List<Follow> Follows = [];
    public Dictionary<string, List<Message>> Messages = [];

    public string[]? Output { get; set; }

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