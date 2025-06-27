


namespace mb.Command
{

    public class WallCommand(string userName) : ICommand, ICommandBuilder
    {
        public string UserName { get; } = userName;

        public static ICommand FromInput(string[] input)
        {
            return new WallCommand(input[0]);
        }
    }
}