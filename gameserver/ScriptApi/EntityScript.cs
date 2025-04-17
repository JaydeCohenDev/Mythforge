using Newtonsoft.Json;

namespace ScriptApi;

public abstract class EntityScript : ScriptBase
{
    [JsonIgnore] public required Entity Entity;
    
    public virtual void OnSpawn() {}
    public virtual void OnGreet(Entity greeter) {}
    public virtual void OnUpdate() {}
    public virtual void OnDestroy() {}
}