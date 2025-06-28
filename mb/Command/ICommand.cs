using mb.Domain;

namespace mb.Command;

public interface ICommand
{
    public MessageBoard Execute(MessageBoard context);
}