namespace GameServer.Core.EntityTraits;

public class SkillTeacher(Skill.Skill skill) : EntityTrait
{
    public Skill.Skill TaughtSkill { get; } = skill;
}