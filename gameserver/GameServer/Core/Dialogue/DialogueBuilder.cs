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


    public void Test()
    {
        var denizen = new Denizen();
        var player = new Player("");
        var dialogue = new DialogueSequence(denizen, player)
        {
            Execute = async (s, d, p) =>
            {
                // d.Tell(player, "says quickly", "What do you want Adventurer?");
                // var response = await s.ShowDialogueOptions([
                //     new DialogueSequence.DialogueOption{
                //         Text = "What's the weather been like recently?",
                //         OnChoose = async () => {

                //         }
                //     }
                // ]);
                // await response.Value.OnChoose!.Invoke();
                // return;
            }
        };
    }
}