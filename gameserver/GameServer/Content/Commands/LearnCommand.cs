using GameServer.Core;
using GameServer.Core.Dialogue;
using GameServer.Core.EntityTraits;
using GameServer.Core.Skill;

namespace GameServer.Content.Commands;

public class LearnCommand : ICommand
{
    public async Task Execute(Player player, string[] args)
    {
        if (args.Length < 1)
        {
            await player.SendAsync("Learn what?");
            return;
        }

        string? skillName = args[0];
        Skill? skill = Skill.All.FirstOrDefault(s => s.Name.Contains(skillName, StringComparison.InvariantCultureIgnoreCase));

        if (skill is null)
        {
            await player.SendAsync("That skill doesn't seem to exist.");
            return;
        }

        if (args.Length < 3)
        {
            await player.SendAsync($"Learn {skill.Name} from who?");
            return;
        }

        string? teacherName = args[2];

        Entity? teacher = player.CurrentRoom?.Entities.FirstOrDefault(e => e.Name.Contains(teacherName, StringComparison.InvariantCultureIgnoreCase));

        if (teacher is null)
        {
            await player.SendAsync("You don't see anyone like that.");
            return;
        }

        var skillTeacherTrait = teacher.GetTrait<SkillTeacher>();

        if (skillTeacherTrait is null || skillTeacherTrait.TaughtSkill != skill)
        {
            await player.SendAsync($"{teacher.Name} can not teach you {skill.Name}");
            return;
        }

        // Finally actually learn skill
        var playerSkills = player.GetTrait<SkillUser>();
        int cost = skill.GetLevelCost(playerSkills.GetSkillLevel(skill) + 1);

        await player.SendAsync($"Learning {skill.Name} will cost 🪙 {cost}. Are you sure?");
        DialogueSequence.DialogueOption? response = await DialogueSequence.ShowDialogueOptions(player, new CancellationToken(), [
            new DialogueSequence.DialogueOption{
                Text = "YES",
                OnChoose = () => {
                    return Task.FromResult("yes");
                }
            },
            new DialogueSequence.DialogueOption{
                Text = "NO",
                OnChoose = () => {
                    return Task.FromResult("no");
                }
            },
        ]);

        string? option = await response?.OnChoose?.Invoke();
        if (option != "yes")
        {
            return;
        }

        bool playerHasEnoughGold = true;

        if (!playerHasEnoughGold)
        {
            await player.SendAsync("You don't have enough gold!");
            return;
        }

        playerSkills.LevelUpSkill(skill);
        await player.SendAsync($"You gained a level in {skill.Name} from {teacher.Name}!");

        return;
    }

    public string[] GetAliases() => ["learn"];
}