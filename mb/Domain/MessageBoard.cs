using mb.Command;

namespace mb.Domain;

public class MessageBoard
{
    public List<Follow> Follows = [];
    public Dictionary<string, List<Message>> Messages = [];
}