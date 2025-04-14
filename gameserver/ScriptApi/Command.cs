namespace ScriptApi;

public interface ICommandBridge
{
    
}

public interface ICommand
{
    public string[] GetAliases();
    public Task Execute(Entity player, string[] args);
}