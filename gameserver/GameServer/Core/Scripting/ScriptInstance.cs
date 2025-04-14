using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using ScriptApi;

namespace GameServer.Core.Scripting;

public class ScriptInstance
{
    public Action? OnRuntimeScriptChanged;
    
    public int Id { get; set; }
    public string ScriptClassName { get; set; } = string.Empty;
    [NotMapped]
    public ScriptBase? RuntimeScript
    {
        get;
        set;
    }

    
    public ScriptInstance() {}

    public void ReloadRuntimeScript()
    {
        RuntimeScript = ScriptManager.CreateScript<ScriptBase>(ScriptClassName);
        OnRuntimeScriptChanged?.Invoke();
        Console.WriteLine($"Reloaded script {ScriptClassName}");
    }
}