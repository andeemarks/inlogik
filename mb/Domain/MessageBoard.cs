using mb.Command;

namespace mb.Domain;

public class MessageBoard
{
    public List<Follow> Follows = [];
    public object Messages = new();
}