using GameServer.Core;
using GameServer.Core.Messaging;
using Microsoft.AspNetCore.SignalR;

namespace GameServer.Content.Commands;

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
        Room? room = player.CurrentRoom;
        if (room is null) return;
        
        World.Db.Entry(room).Collection(r => r.Entities).Load();
        World.Db.Entry(room).Collection(r => r.Exits).Load();

        string? output = new MessageBuilder()
            .AddRoomName(room).AddBreak()
            //.AddTagList(room.Tags).AddBreak(2)
            .AddText(room.Description).AddBreak(2)
            .AddEntityPressenceList("> ", [.. room.Entities]).AddBreak()
            .AddText("Exits:").AddBreak()
            .AddRoomList([.. room.Exits])
            .Build();

        Game.HubContext.Clients.Client(player.GetConnectionId()).SendAsync("ShowMessage", output);
    }
}
