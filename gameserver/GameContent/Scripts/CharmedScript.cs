using ScriptApi;

namespace GameContent.Scripts;

public enum CharmAggressionState
{
    Passive, Neutral, Aggressive
}

public enum CharmFollowState
{
    Follow, Wait
}

public class CharmedScript : EntityScript
{
    public virtual Entity Master { get; set; }
    public virtual CharmAggressionState AggressionState { get; set; } = CharmAggressionState.Neutral;
    public virtual CharmFollowState FollowState { get; set; } = CharmFollowState.Follow;

    public void TryNegate()
    {
        var creature = Entity.GetScript<CreatureScript>();
        if (creature == null)
            return;

        if (creature.Creature.MakeSavingThrow(SavingThrow.Spells, 0))
        {
            Master.Tell(new Message($"{Entity.Name} has broken free of your charm!"));
            Entity.RemoveScript(this);
        }
    }

}