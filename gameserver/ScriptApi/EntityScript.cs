namespace ScriptApi;

public abstract class EntityScript
{
    public required Entity Entity { get; init; }
    
    public virtual void OnSpawn() {}
    public virtual void OnGreet(Entity greeter) {}
    public virtual void OnUpdate() {}
    public virtual void OnDestroy() {}
}