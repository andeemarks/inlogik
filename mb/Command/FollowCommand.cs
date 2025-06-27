using mb.Domain;

namespace mb.Command
{

    public class FollowCommand(string userName, string projectName) : ICommand
    {
        public string UserName { get; } = userName;
        public string ProjectName { get; } = projectName;

        public List<Follow> Execute(MessageBoard context)
        {
            var currentFollows = context.Follows;
            var newFollow = new Follow(UserName, ProjectName);

            if (!currentFollows.Contains(newFollow))
            {
                currentFollows.Add(newFollow);
            }

            return currentFollows;
        }
    }
}