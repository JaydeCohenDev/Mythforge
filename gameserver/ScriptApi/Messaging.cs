using System.Text;

namespace ScriptApi;

public interface IMessageStyle
{
    void Apply(ref string text);
}

public class TextColor(string color) : IMessageStyle
{
    public void Apply(ref string text)
    {
        text = $"<span style='color: {color}'>{text}</span>";
    }
}

public class TextBold : IMessageStyle
{
    public void Apply(ref string text)
    {
        text = $"<b>{text}</b>";
    }
}

public class TextUnderline : IMessageStyle
{
    public void Apply(ref string text)
    {
        text = $"<u>{text}</u>";
    }
}

public class TextItalic : IMessageStyle
{
    public void Apply(ref string text)
    {
        text = $"<i>{text}</i>";
    }
}

public class TextStrikethrough : IMessageStyle
{
    public void Apply(ref string text)
    {
        text = $"<s>{text}</s>";
    }
}

public class TextGradient(string fromColor, string toColor) : IMessageStyle
{
    public void Apply(ref string text)
    {
        text = $"<span style='background-image: linear-gradient(to right, {fromColor}, {toColor}); color: transparent; background-clip: text;'>{text}</span>";
    }
}

public class TextClass(string className) : IMessageStyle
{
    public void Apply(ref string text)
    {
        text = $"<span class='{className}'>{text}</span>";
    }
}

public class Message
{
    protected StringBuilder _builder = new();
    
    public string Build() => _builder.ToString();

    public Message() {}
    
    public Message(string text, params IMessageStyle[] styles)
    {
        Append(text, styles);
    }
    
    public Message Append(string text, params IMessageStyle[] styles)
    {
        foreach(var style in styles)
            style.Apply(ref text);
        _builder.Append(text);
        return this;
    }

    public Message AppendLine(string text, params IMessageStyle[] styles)
    {
        Append(text, styles);
        AppendBreak();
        return this;
    }

    public Message AppendBreak(int num = 1)
    {
        for(int i = 0; i < num; i++)
            _builder.Append("<br/>");
        return this;
    }
    
    
}