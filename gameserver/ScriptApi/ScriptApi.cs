namespace ScriptApi;

public interface IScriptApi
{
    public Task<Entity> SpawnEntity(Room room);
}