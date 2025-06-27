namespace mb.Command;

public interface ICommandBuilder
{
    public abstract static ICommand FromInput(string[] input);
}