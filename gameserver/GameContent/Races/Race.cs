using ScriptApi;

namespace GameContent.Races;

public abstract class Race
{
    public static Race Human { get; } = new Human();
    public static Race Elf { get; } = new Elf();
    public static Race Dwarf { get; } = new Dwarf();
    public static Race Halfling { get; } = new Halfling();
    
    public abstract string Name { get; }
    public abstract Message GetDescription();
}