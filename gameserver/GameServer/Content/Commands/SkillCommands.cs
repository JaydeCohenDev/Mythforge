using GameServer.Core;
using GameServer.Core.EntityTraits;
using GameServer.Core.Messaging;
using GameServer.Core.Skill;

namespace GameServer.Content.Commands;

public class SkillsCommand : ICommand
{
    public Task Execute(Player player, string[] args)
    {
        var skillUser = player.GetTrait<SkillUser>()!;

        var message = new MessageBuilder();
        message.AddText("=== Your skills ===");
        message.AddText("<pre>");

        skillUser.SkillLevels.ToList().ForEach(s =>
        {
            message.AddText($"<span>{s.Key}Lv.{s.Value.ToString().PadLeft(2)} → 🪙 {s.Key.GetLevelCost(s.Value + 1)} to train</span>").AddBreak();
        });
        message.AddText("</pre>");

        player.SendAsync(message.Build());

        return Task.CompletedTask;
    }

    public string[] GetAliases() => ["skills"];
}

public class SkillListCommand : ICommand
{
    public Task Execute(Player player, string[] args)
    {
        if (args.Length == 0)
        {

            return Task.CompletedTask;
        }
        else
        {
            string? skillName = string.Join(' ', args);

            if (skillName == "list")
            {
                MessageBuilder? message = new MessageBuilder()
                    .AddText("== All avaliable skills ==")
                    .AddBreak(2);

                Skill.All.ForEach(s =>
                {
                    message.AddText(s);
                });

                player.SendAsync(message.Build());
            }
            else
            {
                Skill? skill = Skill.All.FirstOrDefault(s => s.Name.Contains(skillName, StringComparison.InvariantCultureIgnoreCase));

                if (skill is null)
                {
                    player.SendAsync("What skill are you talking about?");
                    return Task.CompletedTask;
                }

                MessageBuilder? message = new MessageBuilder()
                    .AddText(skill).AddBreak(2)
                    .AddText(skill.Description).AddBreak(2)
                    .AddText($"Base cost: 🪙 {skill.BaseCost}");

                player.SendAsync(message.Build());
                return Task.CompletedTask;
            }
        }

        return Task.CompletedTask;
    }

    public string[] GetAliases() => ["skill"];
}