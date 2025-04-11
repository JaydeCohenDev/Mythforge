using GameServer.Core.Auth;
using Microsoft.AspNetCore.SignalR;

namespace GameServer.Core.Flows;

public static class CharacterCreationFlow
{
    public static IFlow Build()
    {
        return new FlowBuilder()
            .Step("That character is not known in these lands, are you new? [y/n]", 
                async (context, session, caller, input) =>
            {
                if (input != "y")
                {
                    await caller.SendAsync("ShowMessage", "Then tell me again.");
                    context.EndFlow();
                    session.TempData.Remove("stepIndex");
                    session.CurrentFlow = LoginFlow.Build();
                    await session.CurrentFlow.Start(session, caller);
                }
            })
            .Step("Reveal the cipher that guards your soul. <span style='color: gray'>[enter password]</span>", 
                (context, session, caller, input) =>
            {
                session.TempData["password"] = input;
                return Task.CompletedTask;
            })
            .Step("Confirm your cipher to seal the pact. <span style='color: gray'>[confirm password]</span>", 
                async (context, session, caller, input) =>
            {
                if (input != (string)session.TempData["password"])
                {
                    await caller.SendAsync("ShowMessage", "You have failed to seal the pact.");
                    session.TempData.Remove("password");

                    await Task.Delay(1000);

                    context.EndFlow();
                    session.CurrentFlow = LoginFlow.Build(); 
                    await session.CurrentFlow.Start(session, caller);
                }
            })
            .End(async (session, caller) =>
            {
                var name = session.TempData["name"].ToString();
                var password = session.TempData["password"].ToString();

                World.Db.Accounts.Add(new Account { Name = name, Password = password });
                await World.Db.SaveChangesAsync();

                session.TempData.Remove("name");
                session.TempData.Remove("password");
                
                await caller.SendAsync("ShowMessage", $"Your pact is sealed, {name}!");
                
                
                session.CurrentFlow = MainGameFlow.Build();
                await session.CurrentFlow.Start(session, caller);
            })
            .Build("character creation");
    }
}