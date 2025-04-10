using GameServer.Core;

namespace GameServer.Content.Commands;

public class GotoCommand : ICommand
{
    public Task Execute(Player player, string[] args)
    {
        string? roomName = string.Join(" ", args);

        Room? room = player.CurrentRoom!.Exits.FirstOrDefault(exit => exit.Name.Contains(roomName, StringComparison.InvariantCultureIgnoreCase));
        if (room is null)
        {
            player.SendAsync("You don't see anywhere like that.");
            return Task.CompletedTask;
        }

        player.SendAsync($"You make your way toward {room.Name}");
        room.AddEntity(player);
        return Task.CompletedTask;
    }

    public string[] GetAliases() => ["goto", "walkto"];
}
