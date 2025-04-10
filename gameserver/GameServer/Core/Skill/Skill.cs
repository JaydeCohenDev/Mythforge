using GameServer.Core.Messaging;
using GameServer.Core.Unlocks;

namespace GameServer.Core.Skill;

public class Skill
{
    public static List<Skill> All { get; } = [];
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int BaseCost = 100;
    public Dictionary<int, List<Unlock>> Unlocks { get; set; } = [];

    public Skill()
    {
        All.Add(this);
    }

    public int GetLevelCost(int level)
    {
        int cost = (int)Math.Pow(2, level) * BaseCost;

        Console.WriteLine(level);

        return cost;
    }

    public override string ToString()
    {
        string? icon = Name.Substring(0, Name.IndexOf(' ') + 1);
        string? text = Name.Replace(icon, "");
        var payload = new
        {
            Icon = icon,
            Name = text,
            Description
        };
        return $"<skill payload='{Payload.Encode(payload)}'>{text}</skill>";
    }
}