using System.Reflection;
using GameContent.Creatures;
using ScriptApi;

namespace GameContent.Commands;

public class SpawnCommand : ICommand
{
    public string[] GetAliases() => ["spawn"];

    public async Task Execute(Player player, string[] args)
    {
        var creatureName = string.Join(' ', args);

        var creatureType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t =>
            t.IsAssignableTo(typeof(Creature)) &&
                             t.Name.Contains(creatureName, StringComparison.InvariantCultureIgnoreCase));
        if (creatureType == null)
        {
            player.Tell(new Message("Unknown creature."));
            return;
        }
        var creature = (Creature?)Activator.CreateInstance(creatureType);

        var entity = await MythforgeGame.Api.SpawnEntity(player.GetRoom());
        creature.ApplyTo(entity);
    }
}