namespace ScriptApi;

public abstract class Entity
{
    public virtual Guid Id { get; init; }
    public virtual string Name { get; init; }
    public virtual string Description { get; init; }
    public virtual string PresenceText { get; init; }

    public abstract Room? GetRoom();
    public abstract void Tell(Message message);
    public abstract void MoveTo(Room room);
}