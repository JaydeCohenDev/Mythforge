using GameServer.Core;

namespace GameServer.Content.Mob;

public abstract class SpawnCondition
{
    public abstract bool CanSpawn(Room room);
}

public class RoomTagSpawnCondition : SpawnCondition
{
    protected RoomTags[] _requiredTags;

    public RoomTagSpawnCondition(params RoomTags[] requiredTags)
    {
        _requiredTags = requiredTags;
    }

    public override bool CanSpawn(Room room)
    {
        foreach (RoomTags tag in _requiredTags)
            if (!room.Tags.Contains(tag))
                return false;

        return true;
    }
}