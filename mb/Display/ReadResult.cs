using System.Text;
using mb.Command;
using mb.Domain;

namespace mb.Display;

public class ReadResult
{
    public static string[] For(MessageBoard context, ReadCommand command)
    {
        List<string> result = [];
        var foundProject = context.Messages.ContainsKey(command.ProjectName);
        if (!foundProject)
        {
            return [];
        }

        var displayedUserNames = new List<string>();
        foreach (var message in context.TimeLineForProject(command.ProjectName))
        {
            if (!displayedUserNames.Contains(message.UserName))
            {
                displayedUserNames.Add(message.UserName);
                result.Add(message.UserName);
            }
            result.Add(message.ToString());
        }

        return [.. result];
    }
}