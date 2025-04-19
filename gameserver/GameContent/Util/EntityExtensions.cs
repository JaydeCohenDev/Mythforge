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

    public static void ApplyAffliction(this Entity entity, Affliction affliction)
    {
        affliction.Apply(entity);
    }

    public static void ApplyDamage(this Entity entity, int damage)
    {
        throw new NotImplementedException();
    }

    public static bool MakeSavingThrow(this Entity entity, SavingThrow savingThrow)
    {
        var creature = entity.GetScript<CreatureScript>();
        if(creature?.CreatureType != null)
        {
            return creature.CreatureType.MakeSavingThrow(savingThrow, 0);
        }

        var character = entity.GetScript<CharacterScript>();
        if(character != null)
        {
            return character.MakeSavingThrow(savingThrow, 0);
        }

        return false;
    }

    public static void Kill(this Entity entity) 
    {
        throw new NotImplementedException();
    }
}