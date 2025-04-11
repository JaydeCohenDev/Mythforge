namespace GameServer.Core.Scripting;

public abstract class EntityScript
{
    public Entity Entity { get; set; }
    
    public virtual void OnCreate(){}
    public virtual void OnDestroy(){}
    public virtual void OnUpdate(){}
}