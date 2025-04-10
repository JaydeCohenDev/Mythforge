namespace GameServer.Core.Unlocks;

public abstract class Unlock
{

}

public class CommandUnlock<T> : Unlock where T : ICommand
{
}