
using mb.Command;
using System.Linq;

namespace mb;

public class InputParser
{
    public static ICommand Parse(string input)
    {
        var inputComponents = input.Split();

        if (inputComponents.Length == 1)
        {
            return new ReadCommand(input);
        }

        if (inputComponents[1] == "follows")
        {
            return new FollowCommand(inputComponents[0], inputComponents[2]);
        }

        if (inputComponents[1] == "->")
        {
            var message = string.Join(' ', inputComponents.Skip(3));
            return new PostCommand(inputComponents[0], inputComponents[2].TrimStart('@'), message);
        }

        throw new NotImplementedException();
    }
}