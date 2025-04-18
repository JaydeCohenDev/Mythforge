using GameServer.Core.Auth;
using GameServer.Hubs;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace GameServer.Core;

public static class Game
{
    public static Action<string>? OnPlayerConnected;
    public static Action<string>? OnPlayerDisconnected;
    public static IHubContext<GameHub> HubContext { get; set; } = null!;

    public static World World = null!;
    public static List<Account> Accounts = [];

    public static async Task Init()
    {
        await Load();
    }

    public static async Task Load()
    {
        Console.WriteLine("Loading game data...");
        if (!Directory.Exists("persistent_data"))
            Directory.CreateDirectory("persistent_data");

        if (!Directory.Exists("persistent_data/accounts"))
            Directory.CreateDirectory("persistent_data/accounts");
        
        Console.WriteLine("Loading accounts...");
        var accountFiles = Directory.GetFiles("persistent_data/accounts", "*.json");
        foreach (var file in accountFiles)
        {
            var accountData = await File.ReadAllTextAsync(file);
            var account = JsonConvert.DeserializeObject<Account>(accountData);
            if (account != null)
            {
                Console.WriteLine($"Loaded account: {account.Name}");
                Accounts.Add(account);
            }
        }

        if (File.Exists("persistent_data/world.json"))
        {
            Console.WriteLine("Loading world data...");
            var data = await File.ReadAllTextAsync("persistent_data/world.json");
            World = JsonConvert.DeserializeObject<World>(data) ?? new World();
        }


        Console.WriteLine("Game loaded.");
    }

    public static async Task Save()
    {
        Console.WriteLine("Saving game data...");
        if (!Directory.Exists("persistent_data"))
            Directory.CreateDirectory("persistent_data");

        Console.WriteLine("Saving world...");
        var data = JsonConvert.SerializeObject(World);
        await File.WriteAllTextAsync("persistent_data/world.json", data);

        Console.WriteLine("Saving accounts...");
        if (!Directory.Exists("persistent_data/accounts"))
            Directory.CreateDirectory("persistent_data/accounts");
        foreach (var account in Accounts)
        {
            var accountData = JsonConvert.SerializeObject(account);
            Console.WriteLine("Saving account: " + account.Name);
            await File.WriteAllTextAsync($"persistent_data/accounts/{account.Name}.json", accountData);
        }
        Console.WriteLine("Game saved.");
    }
}