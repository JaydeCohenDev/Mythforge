
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using GameServer.Core.Scripting;

namespace GameServer.Core;

public class Entity
{
    public Guid Id { get; init; }
    public virtual string Name { get; set; } = string.Empty;
    public string? PressenceText { get; set; }
    public string Description { get; set; } = string.Empty;
    
    [NotMapped]
    public List<EntityTrait> Traits { get; init; } = [];

    [JsonIgnore]
    public List<ScriptInstance> Scripts { get; init; } = [];
   
    [JsonIgnore]
    public Room? CurrentRoom { get; private set; }

    public virtual void Tick()
    {
        Traits.ForEach(t => t.Tick());
    }

    public virtual void Destroy()
    {
        CurrentRoom?.Entities.Remove(this);
        CurrentRoom = null;
    }

    public virtual void OnEnterRoom(Room room)
    {
        CurrentRoom = room;
    }

    public Entity AddTraits(params EntityTrait[] traits)
    {
        Traits.AddRange(traits);
        Traits.ForEach(t => t.Owner = this);
        return this;
    }

    public T? GetTrait<T>() where T : EntityTrait
    {
        return Traits.FirstOrDefault(t => t is T) as T;
    }

    public virtual string ToPressenceString()
    {
        return PressenceText ?? Name;
    }
}