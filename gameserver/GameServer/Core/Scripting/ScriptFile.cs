using GameServer.Core.Auth;

namespace GameServer.Core.Scripting;

public class ScriptFile
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Account Author { get; set; }
    public string SourceCode { get; set; }= string.Empty;
    public List<ScriptInstance> Instances { get; set; } = [];

    public ScriptInstance CreateInstance()
    {
        var instance = new ScriptInstance(this);
        Instances.Add(instance);
        return instance;
    }
}