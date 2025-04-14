namespace ScriptApi;

public interface ICommandBridge
{
    
}

public interface ICommand
{
    public string[] GetAliases();

    public virtual bool CanExecute(Player player, string[] args) => true;
    
    public Task Execute(Player player, string[] args);
}