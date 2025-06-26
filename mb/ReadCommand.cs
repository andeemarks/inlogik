
namespace mb
{

    public class ReadCommand(string projectName)
    {
        public string ProjectName { get; } = projectName;

        public List<string> Execute(Dictionary<string, List<string>> messages)
        {
            return messages.GetValueOrDefault(ProjectName, []);
        }
    }
}