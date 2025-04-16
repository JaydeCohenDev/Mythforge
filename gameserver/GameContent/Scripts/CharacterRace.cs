using GameContent.Races;
using ScriptApi;

namespace GameContent.Scripts;

public class CharacterRace : EntityScript
{
    public required Race Race { get; set; }
}