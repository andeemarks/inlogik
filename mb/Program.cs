using mb.Command;

while (true)
{
    var input = Console.ReadLine();
    Console.WriteLine(new ReadCommand("foo"));
}
