using GameServer.Core.Database;
using Microsoft.EntityFrameworkCore;
using ScriptApi;

namespace GameServer.Core.Scripting;

public class ScriptInstance
{
    public Action? OnRuntimeScriptChanged;
    
    public int Id { get; set; }

    private int _lastChangeCode = -1;
    
    private ScriptBase? _runtimeScript;

    public ScriptBase? RuntimeScript
    {
        get => _runtimeScript;
        set
        {
            // Unsubscribe existing event handlers if applicable
            if (_runtimeScript != null)
            {
                _runtimeScript.OnPropertyChangedExternally -= HandleRuntimeScriptChange;
            }

            // Set new value
            _runtimeScript = value;
            
            // Subscribe to property change handling for the new instance
            if (_runtimeScript != null)
            {
                Console.WriteLine($"Tracking changes for script {_runtimeScript.GetType().Name}");
                value.TrackChanges();
                _runtimeScript.OnPropertyChangedExternally += HandleRuntimeScriptChange;
            }

            // Trigger any additional logic or notifications
            OnRuntimeScriptChanged?.Invoke();
        }
    }

    private bool _isModified = false;

    private void HandleRuntimeScriptChange(string propertyName)
    {
        Console.WriteLine($"Detected change in RuntimeScript property '{propertyName}'.");
        _isModified = true; // Mark the instance as having unsaved changes
        DetectChanges();
    }


    public ScriptInstance()
    {
        
    }

    public void DetectChanges()
    {
        if (RuntimeScript != null)
        {
            RuntimeScript.TrackChanges(); // Maintain proper tracking of [Persist]-annotated properties
        }

        if (_isModified) // Only update DB if changes are detected
        {
            _isModified = false; // Reset the modified flag
            using GameDbContext Db = new();
            Db.Entry(this).State = EntityState.Modified;
            Db.SaveChanges();
        }

    }

    public void ReloadRuntimeScript()
    {
        //RuntimeScript = ScriptManager.CreateScript<ScriptBase>(ScriptClassName);
        //Load();
        //OnRuntimeScriptChanged?.Invoke();
        //Console.WriteLine($"Reloaded script {ScriptClassName}");
    }
}