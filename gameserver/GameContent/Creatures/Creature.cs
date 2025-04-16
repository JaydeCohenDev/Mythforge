using GameContent.Misc;
using GameContent.Scripts;
using GameContent.Treasures;
using GameContent.Util;
using Newtonsoft.Json;
using ScriptApi;

namespace GameContent.Creatures;

public abstract class CreatureSpawnContext{}
public class InWild : CreatureSpawnContext{}
public class InLair : CreatureSpawnContext{}
public class InDungeon : CreatureSpawnContext{}

[JsonConverter(typeof(CreatureJsonConverter))]
public abstract class Creature
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract int ArmorClass { get; }
    public abstract HitDice HitDice { get; }
    public abstract int Morale { get; }
    public abstract int Xp { get; }
    public abstract void Attack(Entity target);
    public abstract int GetNumberAppearing(CreatureSpawnContext context);
    public virtual List<TreasureType> GetTreasure() => []; 
    public abstract Dictionary<SavingThrow,int> SavingThrows { get; }

    public void ApplyTo(Entity entity)
    {
        entity.SetName(Name);
        entity.SetDescription(Description);
        var script = entity.AttachScript<CreatureScript>();
        script.SetCreatureType(this);
    }

    public bool MakeSavingThrow(SavingThrow savingThrow, int modifier)
    {
        var target = SavingThrows[savingThrow] + modifier;
        
        var roll = Dice.Roll(1, 20);

        if (roll == 1) return false;
        if(roll == 20) return true;
        return roll >= target;
    }
}

public class CreatureJsonConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        var creature = (Creature) value!;
        writer.WriteValue(creature.GetType().FullName);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        return Activator.CreateInstance(Type.GetType(reader.Value.ToString()));
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Creature);
    }
}