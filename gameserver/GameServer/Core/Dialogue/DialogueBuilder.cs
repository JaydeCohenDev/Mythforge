namespace GameServer.Core.Dialogue;

public class DialogueBuilder
{
    protected DialogueTree _tree = new();

    public DialogueBuilder AddNode()
    {
        return this;
    }

    public DialogueTree Build()
    {
        return _tree;
    }
}