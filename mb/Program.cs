using mb;
using mb.Domain;

var context = new MessageBoard();

while (true)
{
    var input = Console.ReadLine();
    var command = InputParser.Parse(input);
    context = command.Execute(context);
    Console.WriteLine(context);
}
