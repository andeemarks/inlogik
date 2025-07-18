using mb.Command;
using mb.Domain;

namespace mb.Display;

public class WallResult
{
    public static string[] For(MessageBoard context, WallCommand command)
    {
        var timeline = context.TimeLineForUser(command.UserName);
        var result = new List<string>();
        
        foreach (var wallLine in timeline)
        {
            result.Add($"{wallLine.ProjectName} - {wallLine.Message.UserName}: {wallLine.Message}");
        }

        return [.. result];
    }
}