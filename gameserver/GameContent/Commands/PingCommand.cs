using ScriptApi;

namespace GameContent.Commands;

public class PingCommand : ICommand
{
    public string[] GetAliases()
        => ["ping"];

    public Task Execute(Entity player, string[] args)
    {
        player.Tell("Pong!!!!!");
        return Task.CompletedTask;
    }
}