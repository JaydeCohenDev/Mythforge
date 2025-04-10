namespace GameServer.Core;

public interface ITraitUser<T> where T : Trait
{
    public List<T> Traits { get; init; }


}