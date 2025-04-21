namespace GameContent.Items.Armor;

public abstract class Armor : Item
{
    public abstract int AC { get; }
}

public class LeatherArmor : Armor
{
    public override MonetaryValue Value => new() {Gold = 20};
    public override double Weight => 15;
    public override int AC => 13;
}

public class ChainmailArmor : Armor
{
    public override MonetaryValue Value => new() {Gold = 60};
    public override double Weight => 40;
    public override int AC => 15;
}

public class PlateArmor : Armor
{
    public override MonetaryValue Value => new() {Gold = 300};
    public override double Weight => 50;
    public override int AC => 17;
}

public class Shield : Item
{
    public override MonetaryValue Value => new() {Gold = 7};
    public override double Weight => 5;
    public int ACBonus => 1;
}