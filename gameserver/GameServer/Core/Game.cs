using GameServer.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace GameServer.Core;

public static class Game
{
    public static Action<string>? OnPlayerConnected;
    public static Action<string>? OnPlayerDisconnected;
    public static IHubContext<GameHub> HubContext { get; set; } = null!;

    public static World World = new World();

    public static Dictionary<string, ICommand> Commands { get; } = [];

    public static void Init()
    {
        AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => t.IsAssignableTo(typeof(ICommand)) && !t.IsAbstract)
            .ToList().ForEach(t =>
            {
                var command = Activator.CreateInstance(t) as ICommand;
                foreach (string? alias in command!.GetAliases())
                {
                    Commands.Add(alias, command);
                }
            });
    }

    public static ICommand? FindCommand(string name)
        => Commands.FirstOrDefault(c
            => string.Equals(c.Key, name, StringComparison.InvariantCultureIgnoreCase)).Value;

}