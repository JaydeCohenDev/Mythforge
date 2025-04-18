using ScriptApi;

namespace GameServer.Core.Scripting;

public class RoomProxy(Room room) : ScriptApi.Room
{
    public override Guid Id => room.Id;
    public override string Name => room.Name;
    public override string Description => room.Description;
    
    public override List<ScriptApi.Entity> GetEntities()
    {
        List<ScriptApi.Entity> entities = [];
        room.Entities.ForEach(e => entities.Add(new EntityProxy(e)));
        return entities;
    }

    public override List<ScriptApi.Room> GetExits()
    {
        List<ScriptApi.Room> exits = [];
        room.Exits.ForEach(e => exits.Add(new RoomProxy(e)));
        return exits;
    }

    public override void Tell(ScriptApi.Message message)
    {
        room.Entities.OfType<Player>().ToList().ForEach(p => p.SendAsync(message.Build()));
    }
}