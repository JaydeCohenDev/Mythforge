using ScriptApi;

namespace GameServer.Core.Scripting;

public class EntityProxy(Entity entity) : ScriptApi.Entity
{
    public override Guid Id => entity.Id;
    public override string Name => entity.Name;
    public override string Description => entity.Description;
    public override string PresenceText => entity.PressenceText ?? entity.Name;
    
    public override ScriptApi.Room? GetRoom()
    {
        if(entity.CurrentRoom is not null)
            return new RoomProxy(entity.CurrentRoom);
        return null;
    }

    public override void Tell(Message message)
    {
        if (entity is Player player)
        {
            player.SendAsync(message.Build());
        }
    }

    public override void MoveTo(ScriptApi.Room room)
    {
        Room? r = World.Db.Rooms.Find(room.Id);
        Entity? e = World.Db.Entities.Find(entity.Id);
        if (r is not null && e is not null)
        {
            r.AddEntity(e);
        }
        World.Db.SaveChanges();
    }

    public override T AttachScript<T>()
    {
        EntityScript script = Activator.CreateInstance<T>();

        entity.Scripts.Add(new ScriptInstance{
            ScriptClassName = script.GetType().Name,
            RuntimeScript = script
        });
        World.Db.SaveChanges();
        
        return script as T;
    }
}