using ScriptApi;
using ScriptApi.Flow;

namespace GameContent.Flows;

public class LoginFlow : ScriptFlow
{
    private const string HEADER = @"<pre style='line-height: 1.2rem'>
  __  __       _   _      __                               
 |  \/  |     | | | |    / _|                              
 | \  / |_   _| |_| |__ | |_ ___  _ __ __ _  ___           
 | |\/| | | | | __| '_ \|  _/ _ \| '__/ _` |/ _ \          
 | |  | | |_| | |_| | | | || (_) | | | (_| |  __/          
 |_|  |_|\__, |\__|_|_|_|_| \___/|_|  \__, |\___|    _     
          __/ |     | |                __/ |        | |    
         |___/      | |     ___  __ _ |___/_ __   __| |___ 
                    | |    / _ \/ _` |/ _ \ '_ \ / _` / __|
                    | |___|  __/ (_| |  __/ | | | (_| \__ \
                    |______\___|\__, |\___|_| |_|\__,_|___/
                                 __/ |                     
                                |___/ 

     A collaborative text-based fantasy sandbox mmo.                     
</pre>";
    
    public override void Build(ScriptFlowBuilder builder)
    {
        builder.AddStep(
            new Message(HEADER).AppendBreak(2)
                .Append("What name are you known by? ")
                .AppendLine("[enter character name]", new TextColor("gray")),
                async (api, input) =>
                {
                    api.StoreTemp("name", input);
                    bool hasAccount = await api.HasAccount(input);

                    if (!hasAccount)
                    {
                        await api.StartFlow(new CharacterCreationFlow());
                        return;
                    }
                }
            );
        
        builder.AddStep(
            new Message().Append("Reveal the cipher that guards your soul. ")
                .AppendLine("[enter password]", new TextColor("gray")),
                async (api, input) =>
                {
                    string name = api.GetTemp("name") as string ?? "";
                    bool validLogin = await api.ValidateLogin(name, input);
                    if(validLogin)
                    {
                        await api.TellUser(new Message("Welcome back, " + api.GetTemp("name") + "!"));
                        api.FinalizeLogin();
                        Console.WriteLine("Resuming main game flow...");
                        await api.ResumeMainGameFlow();
                    }
                    else
                    {
                        await api.TellUser(new Message("The cipher falters. Attempt the rite again."));
                        api.RemoveTemp("name");
                        await Task.Delay(1000);
                        api.RestartCurrentFlow();
                    }
                }
            );
    }
}