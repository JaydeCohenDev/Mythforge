

using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using GameServer.Content;
using GameServer.Core.Messaging;
using Microsoft.AspNetCore.SignalR;

namespace GameServer.Core;


public class Room
{
    public static readonly Dictionary<string, Room> All = [];

    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    [JsonConverter(typeof(TagListJsonConverter<RoomTags>))]
    public List<RoomTags> Tags { get; set; } = [];
    public List<Entity> Entities { get; init; } = [];

    [JsonConverter(typeof(RoomListJsonConverter))]
    public List<Room> Exits { get; init; } = [];

    public Room()
    {

    }

    public Room Link(Room room)
    {
        Exits.Add(room);
        room.Exits.Add(this);
        return this;
    }

    public void Tick()
    {
        Entities.ForEach(e => e.Tick());
    }

    public void AddEntity(Entity entity)
    {
        entity.OnEnterRoom(this);
    }

    public Task SendAsync(params object[] args)
        => Game.HubContext.Clients.Group(Name).SendAsync("ShowMessage", args);

    public override string ToString()
    {
        return $"<room payload='{Payload.Encode(this)}'>{Name}</room>";
    }
}

internal class RoomListJsonConverter : JsonConverter<List<Room>>
{
    public override List<Room>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, List<Room> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (Room? room in value)
        {
            writer.WriteStringValue(room.Id);
        }
        writer.WriteEndArray();
    }
}

internal class TagListJsonConverter<T> : JsonConverter<List<T>> where T : Enum
{
    public override List<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (T? tag in value)
        {
            writer.WriteStringValue(Enum.GetName(typeof(T), tag));
        }
        writer.WriteEndArray();
    }
}