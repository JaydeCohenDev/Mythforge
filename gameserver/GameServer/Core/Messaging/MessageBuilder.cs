using System.Text;

namespace GameServer.Core.Messaging;

public class MessageBuilder
{
    protected StringBuilder _stringBuilder = new();

    public MessageBuilder AddText(string text)
    {
        _stringBuilder.Append(text);

        return this;
    }

    public MessageBuilder AddText(object obj)
    {
        _stringBuilder.Append(obj.ToString());

        return this;
    }

    public MessageBuilder AddDialogue(Entity sayer, string method, string text)
    {
        string? payload = Payload.Encode(new
        {
            SayerName = sayer.Name,
            SayMethod = method,
            Message = text
        });

        _stringBuilder.Append($"<dialogue payload={payload}></dialogue>");
        return this;
    }

    public MessageBuilder AddBreak(int num = 1)
    {
        for (int i = 0; i < num; i++)
            _stringBuilder.Append("<br/>");

        return this;
    }

    public MessageBuilder AddRoomName(Room room)
    {
        _stringBuilder.Append(room);

        return this;
    }

    private static string GetDenizenText(Denizen denizen)
    {
        return denizen.ToString();
    }

    private static string GetDenizenWrapPrefix(Denizen denizen)
        => $"<npc payload='{Payload.Encode(denizen)}'>";

    private static string GetDenizenWrapPostfix(Denizen denizen)
        => $"</npc>";

    public MessageBuilder AddDenizenName(Denizen denizen)
    {
        _stringBuilder.Append(GetDenizenText(denizen));

        return this;
    }

    public MessageBuilder AddEntityName(Entity entity)
    {
        if (entity is Denizen denizen)
        {
            AddDenizenName(denizen);
        }
        else
        {
            _stringBuilder.Append(entity.Name);
        }

        return this;
    }

    public MessageBuilder AddEntityPressenceList(string prefix = "", params Entity[] entities)
    {
        foreach (Entity? e in entities)
        {
            AddText(prefix);
            if (e is Denizen denizen)
            {
                AddDenizenPressence(denizen);
            }
            else
            {
                AddText(e.ToPressenceString());
            }


            AddBreak();
        }

        return this;
    }

    public MessageBuilder AddRoomList(params Room[] rooms)
    {
        foreach (Room? room in rooms)
        {
            AddText("> ");
            AddRoomName(room);
            AddBreak();
        }

        return this;
    }

    public MessageBuilder AddDenizenPressence(Denizen denizen)
    {
        string? pressence = (denizen.PressenceText ?? denizen.Name)
            .Replace(denizen.Name, GetDenizenText(denizen))
            .Replace("<name>", GetDenizenWrapPrefix(denizen))
            .Replace("</name>", GetDenizenWrapPostfix(denizen));


        _stringBuilder.Append(pressence);

        return this;
    }

    public MessageBuilder AddTagList<T>(List<T> tags) where T : Enum
    {
        _stringBuilder.Append("[ ");
        _stringBuilder.AppendJoin(", ", tags.Select(t => t));
        _stringBuilder.Append(" ]");

        return this;
    }

    public string Build()
    {
        return _stringBuilder.ToString();
    }
}