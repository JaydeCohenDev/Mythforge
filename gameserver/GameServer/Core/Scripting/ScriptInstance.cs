using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using ScriptApi;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace GameServer.Core.Scripting;

public class ScriptInstance
{
    public Action? OnRuntimeScriptChanged;
    
    public int Id { get; set; }
    public string ScriptClassName { get; set; } = string.Empty;
    
    public string? ScriptData { get; set; } = string.Empty;
    
    [NotMapped]
    private ScriptBase? _runtimeScript;
    [NotMapped]
    public ScriptBase? RuntimeScript
    {
        get => _runtimeScript;
        set
        {
            if(_runtimeScript != null)
                _runtimeScript.OnSaveRequested -= Save;
            
            _runtimeScript = value;
            
            if(_runtimeScript != null)
                _runtimeScript.OnSaveRequested += Save;
            
            OnRuntimeScriptChanged?.Invoke();
        }
    }

    public void Save()
    {
        if (RuntimeScript == null) return;
        
        ScriptData = JsonConvert.SerializeObject(RuntimeScript);
    }

    public void Load()
    {
        if(ScriptData is null || RuntimeScript is null) return;

        JsonConvert.PopulateObject(ScriptData, RuntimeScript);
    }

    public ScriptInstance()
    {
        
    }

    public void ReloadRuntimeScript()
    {
        RuntimeScript = ScriptManager.CreateScript<ScriptBase>(ScriptClassName);
        Load();
        OnRuntimeScriptChanged?.Invoke();
        Console.WriteLine($"Reloaded script {ScriptClassName}");
    }
}