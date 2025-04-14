using ScriptApi;

namespace GameServer;

public class CommandHandler
{
    public static Dictionary<string, ICommand?> Commands { get; } = [];
    
    public static void RegisterCommand(ICommand? command)
    {
        Console.WriteLine($"Registering command: {command.GetType().Name}");
        foreach (string alias in command.GetAliases())
        {
            Console.WriteLine($"> Registering alias: {alias}");
            Commands.Add(alias, command);
        }
    }
}