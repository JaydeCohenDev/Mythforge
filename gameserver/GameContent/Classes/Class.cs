
using GameContent.Scripts;
using Newtonsoft.Json;
using ScriptApi;
using ScriptApi.Ability;

namespace GameContent.Classes;

public abstract class ClassLevel
{
    public required int RequiredExperience {get; init;}
    public required string HitDice {get; init;}
    public required int AbilityBonus  {get; init;}
}

[JsonConverter(typeof(ClassJsonConverter))]
public abstract class Class
{
    public static Class Cleric { get; } = new Cleric();
    public static Class Fighter { get; } = new Fighter();
    public static Class MagicUser { get; } = new MagicUser();
    public static Class Thief { get; } = new Thief();
    
    public abstract string Name { get; init; }
    public abstract  Dictionary<int, ClassLevel> Levels {get;}
    public abstract Message GetDescription();
    public virtual List<Ability> GetDefaultAbilities() => [];
    public abstract Dictionary<SavingThrow, int> GetSaveScores(int level);
    public virtual bool ValidateScores(AttributeScores scores) => true;
    public virtual bool CanWield(Weapon weapon) => true;
    public virtual bool CanUseArmor(Armor armor) => true;
    public virtual bool CanUseShield(Shield shield) => true;
}

public class ClassJsonConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        Class c = (Class) value!;
        writer.WriteValue(c.GetType().FullName);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        return Activator.CreateInstance(Type.GetType(reader.Value.ToString()));
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Class);
    }
}