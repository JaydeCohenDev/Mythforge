namespace GameContent.Items.Weapons;

public abstract class Axe : Weapon {}

public class HandAxe : Axe
{
    public override MonetaryValue Value => new() {Gold = 4};
    public override WeaponSize Size => WeaponSize.Small;
    public override double Weight => 5;
    public override string Damage => "1d6";
}

public class BattleAxe : Axe
{
    public override MonetaryValue Value => new() {Gold = 7};
    public override WeaponSize Size => WeaponSize.Medium;
    public override double Weight => 7;
    public override string Damage => "1d8";
}

public class GreatAxe : Axe
{
    public override MonetaryValue Value => new() {Gold = 14};
    public override WeaponSize Size => WeaponSize.Large;
    public override double Weight => 15;
    public override string Damage => "1d10";
}