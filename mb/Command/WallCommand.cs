


namespace mb.Command
{

    public class WallCommand(string userName) : ICommand
    {
        public string UserName { get; } = userName;

        public static WallCommand FromInput(string[] input)
        {
            return new WallCommand(input[0]);
        }
    }
}