using ScriptApi;

namespace GameServer.Core.Scripting;

public class ScriptInstance
{
    public Action? OnRuntimeScriptChanged;
    
    public Guid Id { get; set; }

    public ScriptBase? RuntimeScript;

    public ScriptInstance()
    {
        
    }
}