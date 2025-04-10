using GameServer.Core;
using GameServer.Core.EntityTraits;

namespace GameServer.Content.Commands;

public class AttackCommand : ICommand
{
    public Task Execute(Player player, string[] args)
    {
        if (args.Length == 0)
        {
            player.SendAsync("Attack what?");
            return Task.CompletedTask;
        }

        string? targetName = string.Join(' ', args);

        Entity? target = player.CurrentRoom!.Entities.FirstOrDefault(e => e.Name.Contains(targetName, StringComparison.InvariantCultureIgnoreCase));

        if (target is null)
        {
            player.SendAsync("You don't see anything like that");
            return Task.CompletedTask;
        }

        var damageableTrait = target.GetTrait<Damageable>();

        if (damageableTrait is null)
        {
            player.SendAsync("You want to attack THAT?");
            return Task.CompletedTask;
        }

        player.GetTrait<Fighting>()?.EngageTarget(damageableTrait);
        player.SendAsync($"You fix your eyes on {target.Name}...");
        return Task.CompletedTask;

    }

    public string[] GetAliases() => ["attack", "kill"];
}
