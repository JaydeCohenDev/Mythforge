using GameContent.Creatures;
using ScriptApi;

namespace GameContent.Scripts;

public class CreatureScript : EntityScript
{
    [Persist] public Creature? CreatureType { get; set; }
    
    public void SetCreatureType(Creature creatureType)
    {
        Console.WriteLine($"Setting creature type to {creatureType.Name}");
        CreatureType = creatureType;
    }
}