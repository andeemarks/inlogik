

namespace mb.Command
{

    public class FollowCommand(string userName, string projectName) : ICommand
    {
        public string UserName { get; } = userName;
        public string ProjectName { get; } = projectName;

        public List<Dictionary<string, string>> Execute(List<Dictionary<string, string>> currentFollows)
        {
            var newFollow = new Dictionary<string, string> { { UserName, ProjectName } };

            if (!currentFollows.Contains(newFollow))
            {
                currentFollows.Add(newFollow);
            }

            return currentFollows;
        }
    }
}