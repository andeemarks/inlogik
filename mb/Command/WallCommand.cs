

namespace mb.Command
{

    public class WallCommand(string userName) : ICommand
    {
        public string UserName { get; } = userName;
    }
}