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
    public virtual WeaponSize Size {get; set;}
    public virtual WeaponType Type {get; set;}
    public virtual WeaponKind Kind {get; set;}
    public virtual int LengthInFeet {get; set;}
    public virtual int RequiredHandsToWield {get;set;}
}