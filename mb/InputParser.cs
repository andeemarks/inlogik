
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
            return FollowCommand.FromInput(inputComponents);
        }

        if (inputComponents[1] == "->")
        {
            return PostCommand.FromInput(inputComponents);
        }

        if (inputComponents[1] == "wall")
        {
            return new WallCommand(inputComponents[0]);
        }

        throw new NotImplementedException();
    }
}