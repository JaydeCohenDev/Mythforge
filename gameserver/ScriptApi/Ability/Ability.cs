namespace ScriptApi.Ability;

public abstract class Ability
{
    public abstract string Name { get; }
    public abstract string Description { get; }

    public virtual void Activate(Entity user, Entity target) {}

}