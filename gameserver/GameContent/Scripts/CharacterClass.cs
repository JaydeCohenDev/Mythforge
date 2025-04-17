using System.Text.Json;
using System.Text.Json.Serialization;
using GameContent.Classes;
using ScriptApi;

namespace GameContent.Scripts;

public class CharacterClass : EntityScript
{
    
    [Persist] public required Class Class { get; set; }
    [Persist] public virtual int Level { get; set; } = 1;
}

