using ScriptApi;

namespace GameContent.Commands;

public class QuitCommand : ICommand
{
    public string[] GetAliases() => ["quit", "exit"];

    public async Task Execute(Player player, string[] args)
    {
        player.Tell(new Message("Goodbye!"));
        await player.Disconnect();
    }
}