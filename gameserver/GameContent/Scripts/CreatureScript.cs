using GameContent.Creatures;
using ScriptApi;

namespace GameContent.Scripts;

public class CreatureScript : EntityScript
{
    [Persist] public Creature Creature { get; set; }
    
    public void SetCreatureType(Creature creature)
    {
        Console.WriteLine($"Setting creature type to {creature.Name}");
        Creature = creature;
    }
}