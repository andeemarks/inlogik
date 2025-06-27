
using mb.Domain;

namespace mb.Command
{

    public class ReadCommand(string projectName) : ICommand
    {
        public string ProjectName { get; } = projectName;

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