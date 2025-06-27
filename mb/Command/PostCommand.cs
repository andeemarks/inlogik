

namespace mb.Command
{

    public class PostCommand(string userName, string projectName, string message) : ICommand
    {
        public string UserName { get; } = userName;
        public string ProjectName { get; } = projectName;
        public string Message { get; } = message;

    }
}