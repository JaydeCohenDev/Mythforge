using GameServer.Core;
using GameServer.Core.Messaging;

namespace GameServer.Content.Mob;

public class Mob : Entity
{
    public static List<Mob> All { get; } = [];

    public List<SpawnCondition> SpawnConditions { get; set; } = [];

    public Mob()
    {
        All.Add(this);
    }

    public override string ToString()
    {
        return $"<mob payload='{Payload.Encode(this)}'>{Name}</mob>";
    }

    public override string ToPressenceString()
    {
        return base.ToPressenceString().Replace(Name, ToString(), StringComparison.InvariantCultureIgnoreCase);
    }
}