using System.Text;
using mb.Command;
using mb.Domain;

namespace mb.Display;

public class ReadResult
{
    public static string[] For(MessageBoard context, ReadCommand command)
    {
        List<string> result = [];
        result.Add(command.ProjectName);
        foreach (var message in context.Messages[command.ProjectName])
        {
            result.Add(message.ToString());
        }

        return [.. result];
    }
}