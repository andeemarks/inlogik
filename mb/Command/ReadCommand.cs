
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

        public List<Message> Execute(MessageBoard context)
        {
            try
            {
                return context.Messages[ProjectName];
            }
            catch (KeyNotFoundException)
            {
                return [];
            }
        }
    }
}