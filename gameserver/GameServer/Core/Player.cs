using System.Text.Json.Serialization;
using GameServer.Core.Auth;
using GameServer.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace GameServer.Core;

public class Player : Entity
{
    public int AccountId { get; set; }
    [JsonIgnore]
    public virtual Account Account { get; set; } = null!;
    public virtual Room LoginRoom { get; set; }

    public string? GetConnectionId()
    {
        return GameHub.GetPlayerSession(this)?.ConnectionId;
    }

    public override void OnEnterRoom(Room room)
    {
        if (CurrentRoom is not null)
        {
            Game.HubContext.Groups.RemoveFromGroupAsync(GetConnectionId(), CurrentRoom.Name);
        }

        LoginRoom = room;
        base.OnEnterRoom(room);

        Game.HubContext.Groups.AddToGroupAsync(GetConnectionId(), room.Name);
    }

    public Task SendAsync(params object[] args)
    {
        string? conId = GetConnectionId();
        if (conId != null)
        {
            return Game.HubContext.Clients.Client(conId).SendAsync("ShowMessage", args);
        }
        
        return Task.CompletedTask;
    }
}
