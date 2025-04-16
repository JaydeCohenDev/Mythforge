using ScriptApi;

namespace GameServer.Core.Scripting;

public class ScriptApiProxy : IScriptApi
{
    public async Task<ScriptApi.Entity> SpawnEntity(ScriptApi.Room room)
    {
        var r = await World.Db.FindAsync<Room>(room.Id);
        
        var e = new Entity();
        r?.AddEntity(e);
        
        return new EntityProxy(e);
    }
}