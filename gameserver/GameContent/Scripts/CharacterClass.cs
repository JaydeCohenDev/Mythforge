using GameContent.Classes;
using ScriptApi;

namespace GameContent.Scripts;

public class CharacterClass : EntityScript
{
    public required Class Class { get; set; }
    public int Level { get; set; } = 1;
}