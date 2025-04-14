using ScriptApi;

namespace GameServer.Core.Scripting;

public class RoomBridge : IRoomBridge
{
    public ScriptApi.Room GetRoom(int id)
    {
        var r = World.Db.Find<Room>(id);
        return new ScriptApi.Room(this)
        {
            Id = r.Id,
            Name = r.Name,
            Description = r.Description
        };
    }

    public void TellRoom(int id, string message)
    {
        Console.WriteLine($"Sending message to room {id}: {message}");
        var r = World.Db.Find<Room>(id);
        r?.Entities.ToList().ForEach(p =>
        {
            if (p is Player player)
            {
                player.SendAsync(message);
                
            }
        });
    }

    public ScriptApi.Entity[] GetEntities(int id)
    {
        var r = World.Db.Find<Room>(id);
        var entityBridge = new EntityBridge();
        return r?.Entities.Select(e =>

            new ScriptApi.Entity(entityBridge)
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                PresenceText = e.PressenceText
            }
        ).ToArray();
    }
}