
using mb.Command;

namespace mb;

public class InputParser
{
    public static ICommand Parse(string input)
    {
        var inputComponents = input.Split();

        if (inputComponents.Length == 1)
        {
            return ReadCommand.FromInput(inputComponents);
        }

        if (inputComponents[1] == "follows")
        {
            return FollowCommand.FromInput(inputComponents);
        }

        if (inputComponents[1] == "->")
        {
            return PostCommand.FromInput(inputComponents);
        }

        if (inputComponents[1] == "wall")
        {
            return WallCommand.FromInput(inputComponents);
        }

        throw new NotImplementedException();
    }
}