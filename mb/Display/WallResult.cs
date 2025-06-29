using mb.Command;
using mb.Domain;

namespace mb.Display;

public class WallResult
{
    public static string[] For(MessageBoard context, WallCommand command)
    {
        List<string> result = [];
        var followedProjects = context.Follows.FindAll(f => f.UserName == command.UserName);
        foreach (var follow in followedProjects)
        {
            var projectName = follow.ProjectName;
            var projectMessages = context.Messages[projectName];
            foreach (var message in projectMessages)
            {
                result.Add(message.ToString());
            }
        }

        return [.. result];
    }
}