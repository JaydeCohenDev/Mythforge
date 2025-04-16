namespace GameServer.Core;

public class Exit(Room from, Room to)
{
    public int Id {get;set;}
    public Room From {get; set;} = from;
    public Room To {get;set;} = to;
}