namespace ScriptApi;

public interface ICommandApi
{
    
}

public interface ICommand
{
    public string[] GetAliases();

    public virtual bool CanExecute(Player player, string[] args) => true;
    
    public Task Execute(Player player, string[] args);
}