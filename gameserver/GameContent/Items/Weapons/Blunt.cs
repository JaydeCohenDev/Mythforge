namespace GameContent.Items.Weapons;

public class Warhammer : Weapon
{
    public override MonetaryValue Value => new() { Gold = 4 };
    public override WeaponSize Size => WeaponSize.Small;
    public override double Weight => 6;
    public override string Damage => "1d6";
}

public class Mace : Weapon
{
    public override MonetaryValue Value => new() { Gold = 6 };
    public override WeaponSize Size => WeaponSize.Medium;
    public override double Weight => 10;
    public override string Damage => "1d8";
}

public class Maul : Weapon
{
    public override MonetaryValue Value => new() { Gold = 10 };
    public override WeaponSize Size => WeaponSize.Large;
    public override double Weight => 16;
    public override string Damage => "1d10";
}