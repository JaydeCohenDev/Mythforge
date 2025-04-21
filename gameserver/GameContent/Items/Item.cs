namespace GameContent.Items;

public abstract class Item
{
    public abstract MonetaryValue Value { get; }
    public abstract double Weight { get; }
}