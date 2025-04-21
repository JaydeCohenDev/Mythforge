namespace GameContent.Items.Weapons;

public abstract class Ammunition : Item {}

public abstract class Bow : Weapon
{
    public abstract List<Type> AmmunitionType { get; }
}

public class Shortbow : Bow
{
    public override MonetaryValue Value => new(){Gold = 25};
    public override WeaponSize Size => WeaponSize.Medium;
    public override double Weight => 2;
    public override string Damage => "1d6";
    public override List<Type> AmmunitionType => [typeof(Arrow)];

    public class Arrow : Ammunition
    {
        public override MonetaryValue Value => new() { Silver = 1 };
        public override double Weight => 0.1;
    }

    public class SilveredArrow : Arrow
    {
        public override MonetaryValue Value => new() { Gold = 2 };
    }
}

public class Longbow : Bow
{
    public override MonetaryValue Value => new(){Gold = 60};
    public override WeaponSize Size => WeaponSize.Large;
    public override double Weight => 3;
    public override string Damage => "1d8";
    
    public override List<Type> AmmunitionType => [typeof(Arrow)];

    public class Arrow : Ammunition
    {
        public override MonetaryValue Value => new() { Silver = 2 };
        public override double Weight => 0.1;
    }

    public class SilveredArrow : Arrow
    {
        public override MonetaryValue Value => new() { Gold = 4 };
    }
}

public class LightCrossbow : Bow
{
    public override MonetaryValue Value => new(){Gold = 30};
    public override WeaponSize Size => WeaponSize.Medium;
    public override double Weight => 7;
    public override string Damage => "1d6";
    public override List<Type> AmmunitionType => [typeof(Bolt)];

    public class Bolt : Ammunition
    {
        public override MonetaryValue Value => new() { Silver = 2 };
        public override double Weight => 0.1;
    }

    public class SilveredBolt : Bolt
    {
        public override MonetaryValue Value => new() { Gold = 5 };
    }
}

public class HeavyCrossbow : Bow
{
    public override MonetaryValue Value => new(){Gold = 50};
    public override WeaponSize Size => WeaponSize.Large;
    public override double Weight => 14;
    public override string Damage => "1d8";
    
    public override List<Type> AmmunitionType => [typeof(Bolt)];

    public class Bolt : Ammunition
    {
        public override MonetaryValue Value => new() { Silver = 4 };
        public override double Weight => 0.1;
    }

    public class SilveredBolt : Bolt
    {
        public override MonetaryValue Value => new() { Gold = 10 };
    }
}