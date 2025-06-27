
using mb.Command;

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

        throw new NotImplementedException();
    }
}