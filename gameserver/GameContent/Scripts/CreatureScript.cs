using GameContent.Creatures;
using ScriptApi;

namespace GameContent.Scripts;

public class CreatureScript : EntityScript
{
    public Creature Creature { get; private set; }
    
    public void SetCreatureType(Creature creature)
    {
        Creature = creature;
        SaveChanges();
    }
}