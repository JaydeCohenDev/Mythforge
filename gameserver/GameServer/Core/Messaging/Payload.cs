using System.Text;
using System.Text.Json;

namespace GameServer.Core.Messaging;

public static class Payload
{
    public static string Encode<T>(T payload)
    {
        string? json = JsonSerializer.Serialize(payload);
        byte[]? bytes = Encoding.UTF8.GetBytes(json);
        string? b64 = Convert.ToBase64String(bytes);
        return b64;
    }
}