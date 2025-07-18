using mb;
using mb.Domain;

var context = new MessageBoard();

while (true)
{
    var input = Console.ReadLine();
    var command = InputParser.Parse(input);
    context = command.Execute(context);
    ShowOutput(context);
}

static void ShowOutput(MessageBoard context)
{
    if (context.Output != null)
    {
        foreach (var line in context.Output)
        {
            Console.WriteLine(line);
        }    
    }
}
