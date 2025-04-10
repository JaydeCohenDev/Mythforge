using System.Text.Json;
using Microsoft.AspNetCore.SignalR;

namespace GameServer.Core.Dialogue;

public abstract class DialogueNode
{
    public string? Id { get; set; }

}

public class DenizenNode : DialogueNode
{
    public string SayMethod { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public List<DialogueNode> ChildNodes { get; set; } = [];
}

public class PlayerOption : DialogueNode
{
    public string Content { get; set; } = string.Empty;

    public DialogueNode NextNode { get; set; } = null!;
}

public class LinkNode(string LinkToId) : DialogueNode
{
    public string LinkToId { get; set; } = string.Empty;
}

public class DialogueTree
{
    public DenizenNode RootNode { get; set; }
}

public abstract class EventSequence
{
    public abstract Task ExecuteSequence(CancellationToken cancellationToken);
}

public class DialogueSequence(Denizen Denizen, Player Player) : EventSequence
{
    public struct DialogueOption
    {
        public string Text { get; set; }
        public Func<Task<string>>? OnChoose { get; set; }
    }

    public required Func<DialogueSequence, Denizen, Player, Task> Execute;

    protected CancellationToken _cancellationToken;

    public override async Task ExecuteSequence(CancellationToken cancellationToken)
    {
        _cancellationToken = cancellationToken;
        await Execute.Invoke(this, Denizen, Player).WaitAsync(cancellationToken);
    }

    public static async Task<DialogueOption?> ShowDialogueOptions(Player palyer, CancellationToken cancellationToken, params DialogueOption[] options)
    {
        ISingleClientProxy? client = Game.HubContext.Clients.Client(palyer.ConnectionId);
        string message = JsonSerializer.Serialize(new
        {
            Options = options.Select(o => o.Text)
        });

        string? result = await client.InvokeAsync<string>("ShowOptions", message, cancellationToken);
        Console.WriteLine(result);

        return options.FirstOrDefault(o => o.Text.Equals(result));
    }
}