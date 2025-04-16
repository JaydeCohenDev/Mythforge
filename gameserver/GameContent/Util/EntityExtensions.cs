using GameContent.Afflictions;
using GameContent.Scripts;
using ScriptApi;

namespace GameContent.Util;

public static class EntityExtensions
{
    public static int GetLevel(this Entity entity)
    {
        var c = entity.GetScript<CharacterClass>();
        return c?.Level ?? 0;
    }

    public static int ApplyAffliction(this Entity entity, Affliction affliction)
    {
        throw new NotImplementedException();
    }

    public static int ApplyDamage(this Entity entity, int damage)
    {
        throw new NotImplementedException();
    }
}