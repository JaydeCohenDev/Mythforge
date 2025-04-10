namespace GameServer.Core.Ability;

public abstract class Ability
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public abstract void Activate(Entity user, Entity target);

}