namespace GameContent.Items.Weapons;

public abstract class Weapon : Item
{
    public abstract WeaponSize Size { get; }
    public abstract string Damage { get; }
}