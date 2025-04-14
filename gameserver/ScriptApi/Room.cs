namespace ScriptApi;

public interface IRoomBridge
{
    public Room GetRoom(int id);
    public void TellRoom(int id, string message);
    public Entity[] GetEntities(int id);
}

public class Room(IRoomBridge bridge)
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;

    public Entity[] GetEntities() => bridge.GetEntities(Id);
    public void Tell(string message) => bridge.TellRoom(Id, message);
}