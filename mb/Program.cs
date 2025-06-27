using mb;

while (true)
{
    var input = Console.ReadLine();
    var command = InputParser.Parse(input);
    Console.WriteLine(command);
}
