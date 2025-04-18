namespace ScriptApi;
public abstract class Room
{
    public virtual Guid Id { get; init; }
    public virtual string Name { get; init; } = string.Empty;
    public virtual string Description { get; init; } = string.Empty;

    public abstract List<Entity> GetEntities();
    public abstract List<Room> GetExits();
    public abstract void Tell(Message message);
}