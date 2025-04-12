namespace ScriptApi;

public interface IEntityBridge
{
    public Entity? GetEntity(Guid id);
    public Room? GetEntityRoom(Guid id);
    public void TellEntity(Guid id, string message);
}

public class Entity(IEntityBridge bridge)
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string PresenceText { get; init; } = string.Empty;

    public Room GetRoom() => bridge.GetEntityRoom(Id);
    public void Tell(string message) => bridge.TellEntity(Id, message);
}