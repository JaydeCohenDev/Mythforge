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
        if(!Room.All.TryGetValue(room.Id, out Room? r))
            throw new InvalidOperationException($"Room with ID {room.Id} not found.");

        if(!Entity.All.TryGetValue(entity.Id, out var e))
            throw new InvalidOperationException($"Entity with ID {entity.Id} not found.");

        r.AddEntity(e);
    }

    public override T AttachScript<T>()
    {
        var script = Activator.CreateInstance<T>();
        var scriptInstance = new ScriptInstance
        {
            RuntimeScript = script
        };
        entity.Scripts.Add(scriptInstance);
        
        return script as T ?? throw new InvalidOperationException("Failed to retrieve script as the correct type.");

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
    }
    
    public override void SetDescription(string description)
    {
        entity.Description = description;
    }
}