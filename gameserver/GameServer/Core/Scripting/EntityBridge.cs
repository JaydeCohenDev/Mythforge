using ScriptApi;

namespace GameServer.Core.Scripting;

public class EntityBridge : IEntityBridge
{
    public ScriptApi.Entity? GetEntity(Guid id)
    {
        var e = World.Db.Find<Entity>(id);
        return new ScriptApi.Entity(this)
        {
            Id = e.Id,
            Name = e.Name,
            Description = e.Description,
            PresenceText = e.PressenceText
        };
    }

    public ScriptApi.Room? GetEntityRoom(Guid id)
    {
        var r = World.Db.Find<Entity>(id)?.CurrentRoom;
        return new ScriptApi.Room(new RoomBridge())
        {
            Id = r.Id,
            Name = r.Name,
            Description = r.Description
        };
    }

    public void TellEntity(Guid id, string message)
    {
        var e = World.Db.Find<Entity>(id);
        if (e is Player p)
        {
            p.SendAsync(message);
        }
    }
}