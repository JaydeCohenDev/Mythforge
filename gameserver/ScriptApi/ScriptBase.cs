using System.ComponentModel;
using System.Reflection;
using Newtonsoft.Json;

namespace ScriptApi;

public abstract class ScriptBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    private readonly Dictionary<string, object?> _propertyValues = new();
    
    [JsonIgnore] public bool IsTracked = false;
    [JsonIgnore] public Action<string>? OnPropertyChangedExternally;

    [JsonIgnore] public Action? OnSaveRequested;
    
    public void SaveChanges() => OnSaveRequested?.Invoke();

    public ScriptBase()
    {
        

    }
    
    protected virtual void OnPropertyChanged(string propertyName)
    {
        Console.WriteLine($"Detected property change of {GetType().Name}.{propertyName}");
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        OnPropertyChangedExternally?.Invoke(propertyName); // Trigger external action
    }

    public void TrackChanges()
    {
        Console.WriteLine($"Starting tracking of {GetType().Name} {this}");
        
        // Get all properties with the [Persist] attribute
        var trackedProperties = GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(p => p.IsDefined(typeof(PersistAttribute), true));

        foreach (var property in trackedProperties)
        {
            var newValue = property.GetValue(this);

            if (!_propertyValues.ContainsKey(property.Name))
            {
                _propertyValues.Add(property.Name, newValue);
                OnPropertyChanged(property.Name); 
                continue;
            }
            
            if (!Equals(_propertyValues[property.Name], newValue))
            {
                _propertyValues[property.Name] = newValue;
                OnPropertyChanged(property.Name); // Notify property change
            }
        }
    }

    public string SerializePersistedProperties()
    {
        // Gather properties with the [Persist] attribute
        var persistedProperties = GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(prop => prop.IsDefined(typeof(PersistAttribute)))
            .Select(prop => new
            {
                Name = prop.Name,
                Value = prop.GetValue(this)
            });

        // Convert to a dictionary for serialization
        var propertyDict = persistedProperties.ToDictionary(
            entry => entry.Name,
            entry => entry.Value
        );

        // Serialize the dictionary to JSON
        return JsonConvert.SerializeObject(propertyDict, Formatting.None);
    }

}

[AttributeUsage(AttributeTargets.Property)]
public class PersistAttribute : Attribute
{
}
