
using mb.Domain;

namespace mb.Command
{

    public class ReadCommand(string projectName) : ICommand, ICommandBuilder
    {
        public string ProjectName { get; } = projectName;

        public static ICommand FromInput(string[] input)
        {
            return new ReadCommand(input[0]);
        }

        public MessageBoard Execute(MessageBoard context)
        {
            return context;
        }
    }
}