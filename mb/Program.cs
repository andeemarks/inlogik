using mb;
using mb.Command;

while (true)
{
    var input = Console.ReadLine();
    var command = InputParser.Parse(input);
    Console.WriteLine(command);
}
