using Newtonsoft.Json;

namespace ScriptApi;


public abstract class Entity
{
    public virtual Guid Id { get; init; }
    public virtual string Name { get; init; }
    public virtual string Description { get; init; }
    public virtual string PresenceText { get; init; }

    public abstract Room? GetRoom();
    public abstract void Tell(Message message);
    public abstract void MoveTo(Room room);
    public abstract T AttachScript<T>() where T : EntityScript;
    public abstract T? GetScript<T>() where T : EntityScript;

    public abstract void SetName(string name);
    public abstract void SetDescription(string description);

    public void RemoveScript(EntityScript script)
    {
        throw new NotImplementedException();
    }
}

public class EntityJsonConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        var entity = (Entity) value!;
        writer.WriteValue(entity.Id);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Entity);
    }
}