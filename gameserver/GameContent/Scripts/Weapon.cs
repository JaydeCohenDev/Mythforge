using ScriptApi;

public enum WeaponSize {
    Small, Medium, Large
}

public enum WeaponType {
    Blunt, Blade
}

public enum WeaponKind {
    Dagger, Staff
}

public class Weapon : ItemScript
{
    public WeaponSize Size {get; set;}
    public WeaponType Type {get; set;}
    public WeaponKind Kind {get; set;}
    public int LengthInFeet {get; set;}
    public int RequiredHandsToWield {get;set;}
}