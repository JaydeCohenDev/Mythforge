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
}