using System.Text.Json.Serialization;
using GameServer.Core.Scripting;
using ScriptApi;

namespace GameServer.Core;

public class Entity
{
    public Guid Id { get; init; }
    public virtual string Name { get; set; } = string.Empty;
    public string? PressenceText { get; set; }
    public string Description { get; set; } = string.Empty;

    [JsonIgnore]
    public virtual List<ScriptInstance> Scripts { get; init; } = [];
   
    [JsonIgnore]
    public virtual Room? CurrentRoom { get; private set; }

    public virtual void Tick()
    {
        Scripts.ForEach(s =>
        {
            s.DetectChanges();
            var script = (s.RuntimeScript as EntityScript);
            // if (script != null)
            // {
            //     if (script.Entity == null)
            //     {
            //         script.Entity = new ScriptApi.Entity(new EntityProxy())
            //         {
            //             Name = Name,
            //             Description = Description,
            //             Id = Id,
            //             PresenceText = ToPressenceString()
            //         };
            //     }
            //     script.OnUpdate();
            // }
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

    public virtual string ToPressenceString()
    {
        return PressenceText ?? Name;
    }
}