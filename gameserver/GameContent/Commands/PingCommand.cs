using ScriptApi;

namespace GameContent.Commands;

public class PingCommand : ICommand
{
    public string[] GetAliases()
        => ["ping"];

    public Task Execute(Player player, string[] args)
    {
        player.Tell(new Message("Pong!!!!!"));
        return Task.CompletedTask;
    }
}