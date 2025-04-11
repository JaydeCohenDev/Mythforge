using Microsoft.AspNetCore.SignalR;

namespace GameServer.Core.Flows;

public static class MainGameFlow
{
    public static IFlow Build()
    {
        return new FlowBuilder()
            .Step(async (context, session, caller, input) =>
            {
                string commandName = input.Split(" ").First();
                string[] args = input.Split(" ").Skip(1).ToArray();

                ICommand? command = Game.FindCommand(commandName);
                if (command is not null)
                {
                    //await command.Execute(player, args);
                    return;
                }

                await caller.SendAsync("ShowMessage", "Command not found");
                
                session.CurrentFlow = Build(); // loop
                await session.CurrentFlow.Start(session, caller);
            })
            .Build("main game");
    }
}