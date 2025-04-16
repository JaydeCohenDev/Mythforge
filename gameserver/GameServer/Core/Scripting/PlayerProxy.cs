using Microsoft.AspNetCore.SignalR;
using ScriptApi;

namespace GameServer.Core.Scripting;

public class PlayerProxy(Player player) : ScriptApi.Player
{
    private readonly EntityProxy _entityProxy = new EntityProxy(player);

    public override Guid Id => _entityProxy.Id;
    public override string Name => _entityProxy.Name;
    public override string Description => _entityProxy.Description;
    public override string PresenceText => _entityProxy.PresenceText;

    public override ScriptApi.Room? GetRoom() => _entityProxy.GetRoom();
    public override void Tell(Message message) => _entityProxy.Tell(message);
    public override void MoveTo(ScriptApi.Room room) => _entityProxy.MoveTo(room);
    public override T AttachScript<T>() => _entityProxy.AttachScript<T>();
    public override T? GetScript<T>() where T : class => _entityProxy.GetScript<T>();

    public override async Task Disconnect()
    {
        await Game.HubContext.Clients.Client(player.GetConnectionId()).SendAsync("disconnect");
    }
}