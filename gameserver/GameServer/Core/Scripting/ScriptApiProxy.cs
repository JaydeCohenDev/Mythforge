using ScriptApi;

namespace GameServer.Core.Scripting;

public class ScriptApiProxy : IScriptApi
{
    public async Task<ScriptApi.Entity> SpawnEntity(ScriptApi.Room room)
    {
        Room.All.TryGetValue(room.Id, out var r);
        
        var e = new Entity();
        r?.AddEntity(e);
        
        return new EntityProxy(e);
    }
}