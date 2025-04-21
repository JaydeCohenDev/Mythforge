namespace GameContent.Items.Weapons;

public class Dagger : Weapon
{
    public override MonetaryValue Value => new() { Gold = 2 };
    public override WeaponSize Size => WeaponSize.Small;
    public override double Weight => 1;
    public override string Damage => "1d4";
}

public class SilverDagger : Dagger
{
    public override MonetaryValue Value => new() { Gold = 25 };
}

public class Shortsword : Weapon
{
    public override MonetaryValue Value => new() { Gold = 6 };
    public override WeaponSize Size => WeaponSize.Small;
    public override double Weight => 3;
    public override string Damage => "1d6";
}

public class Longsword : Weapon
{
    public override MonetaryValue Value => new() { Gold = 10 };
    public override WeaponSize Size => WeaponSize.Medium;
    public override double Weight => 4;
    public override string Damage => "1d8";
}

public class TwoHandedSword : Weapon
{
    public override MonetaryValue Value => new() { Gold = 18 };
    public override WeaponSize Size => WeaponSize.Large;
    public override double Weight => 10;
    public override string Damage => "1d10";
}
