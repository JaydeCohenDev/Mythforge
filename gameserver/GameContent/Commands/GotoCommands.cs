

using ScriptApi;

namespace GameContent.Commands;

public class GotoCommand : ICommand
{
    public string[] GetAliases() => ["goto", "walkto", "g"];
    
    public Task Execute(Player player, string[] args)
    {
        string? roomName = string.Join(" ", args);

        Room? room = player.GetRoom()?.GetExits().FirstOrDefault(exit => exit.Name.Contains(roomName, StringComparison.InvariantCultureIgnoreCase));
        if (room is null)
        {
            player.Tell(new Message("You don't see anywhere like that."));
            return Task.CompletedTask;
        }

        player.Tell(new Message($"You make your way toward {room.Name}"));
        player.MoveTo(room);
        
        LookCommand.SendRoomLook(player);
        
        return Task.CompletedTask;
    }

    
}