


namespace mb.Command
{

    public class PostCommand(string userName, string projectName, string message) : ICommand, ICommandBuilder
    {
        public string UserName { get; } = userName;
        public string ProjectName { get; } = projectName;
        public string Message { get; } = message;

        public static ICommand FromInput(string[] input)
        {
            var message = string.Join(' ', input.Skip(3));
            return new PostCommand(input[0], input[2].TrimStart('@'), message);
        }
    }
}