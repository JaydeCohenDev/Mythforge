using System.Text;
using ScriptApi;

namespace GameContent.Commands;

public class LookCommand : ICommand
{
    public string[] GetAliases() => ["look"];

    public Task Execute(Player player, string[] args)
    {
        SendRoomLook(player);
        return Task.CompletedTask;
    }

    public static void SendRoomLook(Player player)
    {
        Room? room = player.GetRoom();
        if (room is null) return;

        var message = new Message();
        message.AppendLine(room.Name, new TextClass("RoomName"), new TextBold());
        message.AppendLine(room.Description);
        room.GetEntities().ForEach(e => message.AppendLine($"{e.PresenceText} ", new TextClass("Entity")));
        message.AppendBreak();
        message.AppendLine("Exits:");
        room.GetExits().ForEach(e => message.AppendLine($"> {e.Name}", new TextClass("RoomName")));
        
        player.Tell(message);
    }
}