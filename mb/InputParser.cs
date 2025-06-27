
using mb.Command;

namespace mb;

public class InputParser
{
    public static ICommand Parse(string input)
    {
        return new ReadCommand(input);
    }
}