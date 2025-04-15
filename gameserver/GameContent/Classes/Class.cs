using ScriptApi;

namespace GameContent.Classes;

public abstract class Class
{
    public static Class Cleric { get; } = new Cleric();
    public static Class Fighter { get; } = new Fighter();
    public static Class MagicUser { get; } = new MagicUser();
    public static Class Thief { get; } = new Thief();
    
    public abstract string Name { get; init; }
    public abstract Message GetDescription();
}