namespace GameServer.Core;

public abstract class Trait
{

}

public abstract class EntityTrait : Trait
{
    public virtual void Tick() { }
    public Entity Owner = null!;
}