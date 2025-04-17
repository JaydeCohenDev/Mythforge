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
        var script = Activator.CreateInstance<T>();
        var scriptInstance = new ScriptInstance
        {
            RuntimeScript = script
        };
        entity.Scripts.Add(scriptInstance);

        World.Db.SaveChangesAsync().Wait();



        var result = scriptInstance.RuntimeScript;
        return result as T ?? throw new InvalidOperationException("Failed to retrieve script as the correct type.");

    }

    public override T? GetScript<T>() where T : class
    {
        return entity.Scripts
            .Select(s => s.RuntimeScript)
            .OfType<T>()
            .FirstOrDefault();
    }

    public override void SetName(string name)
    {
        entity.Name = name;
        World.Db.SaveChanges();
    }
    
    public override void SetDescription(string description)
    {
        entity.Description = description;
        World.Db.SaveChanges();
    }
}