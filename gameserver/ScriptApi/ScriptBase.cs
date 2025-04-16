using System.ComponentModel;
using Newtonsoft.Json;

namespace ScriptApi;

public abstract class ScriptBase
{
    [JsonIgnore]
    public Action? OnSaveRequested { get; set; }
    
    public void SaveChanges() => OnSaveRequested?.Invoke();
}