namespace GameServer.Core.EntityTraits;

public class SkillUser : EntityTrait
{
    public Dictionary<Skill.Skill, int> SkillLevels { get; set; } = [];

    public int GetSkillLevel(Skill.Skill skill)
    {
        if (!SkillLevels.TryGetValue(skill, out int value))
            return 0;

        return value;
    }

    public void LevelUpSkill(Skill.Skill skill)
    {
        if (!SkillLevels.TryAdd(skill, 1))
            SkillLevels[skill]++;
    }
}