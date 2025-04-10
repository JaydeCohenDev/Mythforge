using GameServer.Core;
using GameServer.Core.Messaging;

namespace GameServer.Content.Commands;

public class GreetCommand : ICommand
{
    public Task Execute(Player player, string[] args)
    {
        if (args.Length <= 0)
        {
            player.SendAsync("Greet who?");
            return Task.CompletedTask;
        }

        string? denizenName = string.Join(' ', args);

        var denizen = player.CurrentRoom?.Entities.FirstOrDefault(e =>
        {
            return e.Name.Contains(denizenName, StringComparison.InvariantCultureIgnoreCase) && e is Denizen;
        }) as Denizen;

        if (denizen is null)
        {
            player.SendAsync("You don't see anyone like that.");
            return Task.CompletedTask;
        }

        string? message = new MessageBuilder()
            .AddText("You greet ")
            .AddDenizenName(denizen)
            .Build();
        player.SendAsync(message);

        denizen.Greet(player);
        return Task.CompletedTask;
    }

    public string[] GetAliases() => ["greet"];
}