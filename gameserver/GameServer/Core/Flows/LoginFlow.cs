using GameServer.Core.Auth;
using GameServer.Core.Messaging;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace GameServer.Core.Flows;

public static class LoginFlow
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
    
    public static IFlow Build()
    {
        return new FlowBuilder()
            .Step(new MessageBuilder()
                .AddText(HEADER).AddBreak(3)
                .AddText("What name are you known by? <span style='color: gray'>[enter character name]</span>")
                .Build(),
                async (context, session, caller, input) =>
                {
                    session.TempData["name"] = input;
                    session.Name = input;
                    
                    
                    
                    Account? account = await World.Db.Accounts
                        .FirstOrDefaultAsync(a =>
                        a.Name == session.Name);

                    if (account is null)
                    {
                        context.EndFlow();
                        session.CurrentFlow = CharacterCreationFlow.Build();
                        await session.CurrentFlow.Start(session, caller);
                        return;
                        
                    }
                    
                    
                    

                    session.Account = account;
                })
            .Step("Reveal the cipher that guards your soul. <span style='color: gray'>[enter password]</span>",
                async (context, session, caller, input) =>
                {
                    if (session.Account.Password == input)
                    {
                        await World.Db.Entry(session.Account).Reference(a => a.Player).LoadAsync();
                        await World.Db.Entry(session.Account.Player).Reference(p => p.CurrentRoom).LoadAsync();
                        await World.Db.Entry(session.Account.Player).Reference(p => p.LoginRoom).LoadAsync();
                        session.Player = session.Account.Player;

                        await caller.SendAsync("ShowMessage", "Welcome back, " + session.Name + "!");
                        
                        session.Player.LoginRoom.AddEntity(session.Player);
                        
                        session.CurrentFlow = MainGameFlow.Build();
                    }
                    else
                    {
                        await caller.SendAsync("ShowMessage", "The cipher falters. Attempt the rite again.");
                        session.TempData.Remove("name");
                        await Task.Delay(1000);
                        session.CurrentFlow = Build();
                    }

                    context.EndFlow();
                    await session.CurrentFlow.Start(session, caller);
                })
            .Build("login");
    }
}