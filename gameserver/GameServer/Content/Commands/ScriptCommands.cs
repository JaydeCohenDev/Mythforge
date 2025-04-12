using System.Text.Json;
using GameServer.Core;
using GameServer.Core.Scripting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace GameServer.Content.Commands;

public class CreateScriptCommand : ICommand
{
    public string[] GetAliases() => ["#script/create"];

    public bool CanExecute(Player player, string[] args)
    {
        return player.Account.Permissions.Contains("admin");
    }

    public async Task Execute(Player player, string[] args)
    {
        if (args.Length != 1)
        {
            await player.SendAsync("#script/create [script name]");
        }

        var scriptName = args[0];
        var conId = player.GetConnectionId();

        var existingScript = await World.Db.Scripts.FirstOrDefaultAsync(s => s.Name == scriptName);
        if (existingScript != null)
        {
            await player.SendAsync($"Script {scriptName} already exists.");
            return;
        }
        
        var script = new ScriptFile
        {
            Name = scriptName,
            Author = player.Account,
            SourceCode = $"/** Mythforge Script | Author: {player.Account.Name} **/"
        };
        await World.Db.Scripts.AddAsync(script);
        await World.Db.SaveChangesAsync();
        
        Console.WriteLine($"Creating script {scriptName}");
        await Game.HubContext.Clients.Client(conId).SendAsync("GetScript", JsonSerializer.Serialize(new
        {
            script.Id,
            script.Name,
            Author = script.Author.Name,
            script.SourceCode,
        }));
    }
}

public class EditScriptCommand : ICommand
{
    public string[] GetAliases() => ["#script/edit"];

    public bool CanExecute(Player player, string[] args)
    {
        return player.Account.Permissions.Contains("admin");
    }

    public async Task Execute(Player player, string[] args)
    {
        
        if (args.Length != 1)
        {
            await player.SendAsync("#script/edit [script name]");
            return;
        }

        var scriptName = args[0];
        var conId = player.GetConnectionId();
        
        var script = await World.Db.Scripts.Include(scriptFile => scriptFile.Author).FirstOrDefaultAsync(s => s.Name == scriptName);

        if (script == null)
        {
            await player.SendAsync($"Script {scriptName} does not exist.");
            return;
        }

        if (script.Author != player.Account)
        {
            await player.SendAsync($"You do not have permission to edit this script.");
            return;
        }
            
        await Game.HubContext.Clients.Client(conId).SendAsync("GetScript", JsonSerializer.Serialize(new
        {
            script.Id,
            script.Name,
            Author = script.Author.Name,
            script.SourceCode,
        }));
    }
}

public class UploadScriptCommand : ICommand
{
    public string[] GetAliases() => ["#script/upload"];
    
    public Task Execute(Player player, string[] args)
    {
        throw new NotImplementedException();
    }
}

public class DeleteScriptCommand : ICommand
{
    public string[] GetAliases() => ["#script/delete"];
    
    public Task Execute(Player player, string[] args)
    {
        throw new NotImplementedException();
    }
}

public class ReloadScriptCommand : ICommand
{
    public string[] GetAliases() => ["#script/reload"];
    public Task Execute(Player player, string[] args)
    {
        throw new NotImplementedException();
    }
}