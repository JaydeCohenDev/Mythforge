
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using GameServer.Core.Database;
using GameServer.Core.Scripting;
using ScriptApi;

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
    public virtual List<ScriptInstance> Scripts { get; init; } = [];
   
    [JsonIgnore]
    public virtual Room? CurrentRoom { get; private set; }

    public virtual void Tick()
    {
        //Console.WriteLine($"{Name} Tick");
        Traits.ForEach(t => t.Tick());
        if (Name == "box")
        {
            Console.WriteLine($"{Name} Tick");
        }

        
        Scripts.ForEach(s =>
        {
            var script = (s.RuntimeScript as EntityScript);
            if (script != null)
            {
                if (script.Entity == null)
                {
                    script.Entity = new ScriptApi.Entity(new EntityBridge())
                    {
                        Name = Name,
                        Description = Description,
                        Id = Id,
                        PresenceText = ToPressenceString()
                    };
                }
                script.OnUpdate();
            }
        });
    }

    public virtual void Destroy()
    {
        //Sc.ForEach(s => s.OnDestroy());
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