using GameServer.Core;
using Microsoft.EntityFrameworkCore;

namespace GameServer.Content.Commands;

public class EntityCreateCommand : ICommand
{
    public string[] GetAliases() => ["#entity/create"];

    public bool CanExecute(Player player, string[] args)
    {
        return player.Account.Permissions.Contains("admin");
    }

    public async Task Execute(Player player, string[] args)
    {
        var entityName = args.Length == 0 ? "NewEntity" : string.Join(" ", args);

        var entity = new Entity
        {
            Name = entityName,
        };
        
        player.CurrentRoom?.AddEntity(entity);
        await World.Db.SaveChangesAsync();
        
        await player.SendAsync($"{entityName} pops into existence.");
    }
}

public class EntityDeleteCommand : ICommand
{
    public string[] GetAliases() => ["#entity/delete"];

    public bool CanExecute(Player player, string[] args)
    {
        return player.Account.Permissions.Contains("admin");
    }

    public async Task Execute(Player player, string[] args)
    {
        if (args.Length == 0)
        {
            await player.SendAsync("Delete what?");
            return;
        }
        
        var entityName = string.Join(" ", args);
        
        await World.Db.Entry(player.CurrentRoom).Collection(r => r.Entities).LoadAsync();

        var entity = player.CurrentRoom.Entities.FirstOrDefault(e =>
            e.Name.Contains(entityName, StringComparison.InvariantCultureIgnoreCase));

        if (entity is null)
        {
            await player.SendAsync("You don't see anything like that");
            return;
        }

        player.CurrentRoom.Entities.Remove(entity);
        World.Db.Entry(entity).State = EntityState.Deleted;
        await World.Db.SaveChangesAsync();
        
        await player.SendAsync($"{entityName} has been destroyed!");
    }
}
