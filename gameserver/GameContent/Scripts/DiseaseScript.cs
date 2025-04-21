using GameContent.Scripts;
using GameContent.Util;
using ScriptApi;

public class DiseaseScript : EntityScript
{
    public int HoursBeforeActive {get; set;} = 0;

    public override void OnSpawn()
    {
        base.OnSpawn();

        Time.OnHour += OnHour;
    }

    protected void OnHour()
    {
        if(HoursBeforeActive > 0)
        {
            HoursBeforeActive--;
            return;
        }

        var scores = Entity.GetScript<AttributeScores>();
        if(scores != null)
        {
            scores.DrainConstitution(1);
        }

        if(Entity.MakeSavingThrow(SavingThrow.DeathRayPoison))
        {
            Entity.Tell(new Message("You're immune system fights off the disease!"));
            Entity.RemoveScript(this);
        }
    }
}