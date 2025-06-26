

namespace mb
{

    public class FollowCommand
    {
        public FollowCommand(string userName, string projectName)
        {
            UserName = userName;
            ProjectName = projectName;
        }

        public string UserName { get; set; }
        public string ProjectName { get; set; }

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