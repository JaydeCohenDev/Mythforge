using GameServer.Core;
using GameServer.Core.Messaging;
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
        
        string entityName = string.Join(" ", args);
        
        await World.Db.Entry(player.CurrentRoom!).Collection(r => r.Entities).LoadAsync();

        Entity? entity = player.CurrentRoom?.Entities.FirstOrDefault(e =>
            e.Name.Contains(entityName, StringComparison.InvariantCultureIgnoreCase));

        if (entity is null)
        {
            await player.SendAsync("You don't see anything like that");
            return;
        }

        if (entity is Player)
        {
            await player.SendAsync("You can't destroy a player.");
            return;
        }

        World.Db.Remove(entity);
        await World.Db.SaveChangesAsync();
        
        await player.SendAsync($"{entityName} has been destroyed!");
    }
}

public class EntityAttachScriptCommand : ICommand
{
    public string[] GetAliases() => ["#entity/attachscript"];
    
    public async Task Execute(Player player, string[] args)
    {
        if (args.Length < 1)
        {
            await player.SendAsync("What script do you want to attach?");
            return;
        }

        if (args.Length < 2)
        {
            await player.SendAsync("Attach script to what?");
            return;
        }

        var scriptName = args[0];
        
        var scriptFile = await World.Db.Scripts.FirstOrDefaultAsync(s => s.Name == scriptName);

        if (scriptFile is null)
        {
            await player.SendAsync("That script doesn't exist.");
            return;
        }
        
        var entityName = string.Join(" ", args.Skip(1));
        
        await World.Db.Entry(player.CurrentRoom).Collection(r => r.Entities).LoadAsync();
        var entity = player.CurrentRoom.Entities.FirstOrDefault(e =>
            e.Name.Contains(entityName, StringComparison.InvariantCultureIgnoreCase));

        if (entity is null)
        {
            await player.SendAsync("You don't see anything like that");
            return;
        }
        
        entity.Scripts.Add(scriptFile.CreateInstance());
        
        await World.Db.SaveChangesAsync();
        await player.SendAsync($"{entityName} now has {scriptName} attached.");

        return;
    }
}

public class EntityDetachScriptCommand : ICommand
{
    public string[] GetAliases() => ["#entity/detachscript"];
    
    public async Task Execute(Player player, string[] args)
    {
        throw new NotImplementedException();
    }
}

public class EntityListScriptsCommand : ICommand
{
    public string[] GetAliases() => ["#entity/scripts"];
    
    public async Task Execute(Player player, string[] args)
    {
        if (args.Length == 0)
        {
            await player.SendAsync("List scripts of what?");
            return;
        }
        
        var entityName = string.Join(" ", args);
        var entity = player.CurrentRoom?.Entities.FirstOrDefault(e =>
            e.Name.Contains(entityName, StringComparison.InvariantCultureIgnoreCase));

        if (entity is null)
        {
            await player.SendAsync("You don't see anything like that");
            return;
        }
        
        await World.Db.Entry(entity).Collection(e => e.Scripts).LoadAsync();

        var message = new MessageBuilder()
            .AddText($"{entity.Name} has the following scripts attached:").AddBreak(2);
        
        entity.Scripts.ForEach(async s =>
        {
            await World.Db.Entry(s).Reference(s => s.ScriptFile).LoadAsync();
            message.AddText($"> {s.ScriptFile.Name}").AddBreak();
        });
        
        await player.SendAsync(message.Build());
        return;
    }
}