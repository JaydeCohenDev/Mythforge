using System.Text.Json;

namespace GameServer.Core;

public class Region
{
    public static readonly Dictionary<string, Region> All = [];

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public virtual List<Room> Rooms { get; set; } = [];

    
    
    protected Room AddRoom(Room room)
    {
        // room.Id = $"{Name.ToId()}.{room.Name.ToId()}";
        // Room.All.Add(room.Id, room);
        Rooms.Add(room);
        return room;
    }

    public void Tick()
    {
        Console.WriteLine($"{Name} Tick");
        Rooms.ForEach(r => r.Tick());
    }

    public Room AddLinkedSubRooms(Room parentRoom, params Room[] rooms)
    {
        foreach (Room? room in rooms)
        {
            AddRoom(room);
            room.Link(parentRoom);
        }

        return parentRoom;
    }

    public void LinkRooms(params Room[] rooms)
    {
        for (int i = 0; i < rooms.Length; i++)
        {
            for (int j = i + 1; j < rooms.Length; j++)
            {
                rooms[i].Link(rooms[j]);
            }
        }
    }

    public void LinkSequential(params Room[] rooms)
    {
        for (int i = 0; i < rooms.Length; i++)
        {
            int j = (i + 1) % rooms.Length;
            rooms[i].Link(rooms[j]);
        }
    }
}