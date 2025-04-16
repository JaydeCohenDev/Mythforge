using GameContent.Classes;
using GameContent.Races;
using GameContent.Scripts;
using ScriptApi;
using ScriptApi.Flow;

namespace GameContent.Flows;

public class CharacterCreationFlow : ScriptFlow
{
    public override void Build(ScriptFlowBuilder builder)
    {
        builder.AddStep(
            new Message("That character is not known in these lands, are you new? [y/n]"),
            async (api, input) =>
            {
                if (input != "y")
                {
                    await api.TellUser(new Message("Then tell me again..."));
                    api.RestartCurrentFlow();
                }
            });
        builder.AddStep(
            new Message("Select a Race ")
                .Append("[human/elf/dwarf/halfling]  INFO [RACE] for details", new TextColor("gray")),
            async (api, input) =>
            {
                var args = input.Split(' ');
                switch (args[0])
                {
                    case "human":
                        api.StoreTemp("race", Race.Human);
                        break;
                    case "elf":
                        api.StoreTemp("race", Race.Elf);
                        break;
                    case "dwarf":
                        api.StoreTemp("race", Race.Dwarf);
                        break;
                    case "halfling":
                        api.StoreTemp("race", Race.Halfling);
                        break;
                    case "info":

                        if (args.Length < 2)
                        {
                            await api.TellUser(new Message("Please specify a race to view details for."));
                            api.RestartStep();
                            return;
                        }
                        
                        string raceName = args[1];
                        Race? race = raceName switch
                        {
                            "human" => Race.Human,
                            "elf" => Race.Elf,
                            "dwarf" => Race.Dwarf,
                            "halfling" => Race.Halfling,
                            _ => null
                        };

                        if (race == null)
                        {
                            await api.TellUser(new Message("That race is not known."));
                            api.RestartStep();
                            return;
                        }
                        
                        await api.TellUser(new Message()
                            .AppendLine(race.Name, new TextUnderline())
                            .AppendLine(race.GetDescription().Build()));
                        api.RestartStep();
                        break;
                    default:
                        await api.TellUser(new Message("Please select a race."));
                        api.RestartStep();
                        break;
                }
            }
        );
        
        builder.AddStep(
            new Message("Select a Class ")
                .Append("[cleric/fighter/magicuser/theif]  INFO [CLASS] for details", new TextColor("gray")),
            async (api, input) =>
            {
                var args = input.Split(' ');
                switch (args[0])
                {
                    case "cleric":
                        api.StoreTemp("class", Class.Cleric);
                        break;
                    case "fighter":
                        api.StoreTemp("class", Class.Fighter);
                        break;
                    case "magicuser":
                        api.StoreTemp("class", Class.MagicUser);
                        break;
                    case "theif":
                        api.StoreTemp("class", Class.Thief);
                        break;
                    case "info":

                        if (args.Length < 2)
                        {
                            await api.TellUser(new Message("Please specify a class to view details for."));
                            api.RestartStep();
                            return;
                        }
                        
                        string className = args[1];
                        Class? selectedClass = className switch
                        {
                            "cleric" => Class.Cleric,
                            "fighter" => Class.Fighter,
                            "magicuser" => Class.MagicUser,
                            "theif" => Class.Thief,
                            _ => null
                        };

                        if (selectedClass == null)
                        {
                            await api.TellUser(new Message("That class is not known."));
                            api.RestartStep();
                            return;
                        }
                        
                        await api.TellUser(new Message()
                            .AppendLine(selectedClass.Name, new TextUnderline())
                            .AppendLine(selectedClass.GetDescription().Build()));
                        api.RestartStep();
                        break;
                    default:
                        await api.TellUser(new Message("Please select a class."));
                        api.RestartStep();
                        break;
                }
            }
        );
        
        builder.AddStep(
            new Message()
                .Append("Reveal the cipher that guards your soul. ")
                .AppendLine("[enter password]", new TextColor("gray")),
            (api, input) =>
            {
                api.StoreTemp("password", input);
                return Task.CompletedTask;
            });
        
        builder.AddStep(
            new Message()
                .Append("Confirm your cipher to seal the pact. ")
                .AppendLine("[confirm password]", new TextColor("gray")),
            async (api, input) =>
            {
                string p = api.GetTemp("password") as string ?? "";
                if (input != p)
                {
                    await api.TellUser(new Message("You have failed to seal the pact."));
                    api.RemoveTemp("password");
                    await Task.Delay(1000);
                    await api.StartFlow(new LoginFlow());
                }
                
                string? name = api.GetTemp("name") as string;
                string? password = api.GetTemp("password") as string;
        
                Console.WriteLine($"Creating new account for {name}");
                Player player = await api.CreateAccount(name!, password!);

                var characterRace = player.AttachScript<CharacterRace>();
                characterRace.Race = api.GetTemp("race") as Race ?? throw new Exception("Race not set");
                
                var characterClass = player.AttachScript<CharacterClass>();
                characterClass.Class = api.GetTemp("class") as Class ?? throw new Exception("Class not set");
                
                var scores = player.AttachScript<AttributeScores>();
                scores.Generate();
                
                api.RemoveTemp("name");
                api.RemoveTemp("password");
                api.RemoveTemp("race");
                api.RemoveTemp("class");
                
                await api.TellUser(
                    new Message()
                        .AppendLine($"Your pact is sealed, {name}!", new TextColor("cyan"))
                        .AppendLine($"You are a {characterRace.Race.Name} {characterClass.Class.Name}")
                        .AppendLine(scores.ToString())
                        .AppendLine("Welcome to the world of <b>Mythforge: Lengends</b>!", new TextItalic(), new TextGradient("#E3A412", "#D93F7C"))
                );
                

                await api.ResumeMainGameFlow();
            });


        
    }
}