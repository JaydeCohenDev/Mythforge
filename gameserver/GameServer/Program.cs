

using GameServer.Core;
using GameServer.Core.Scripting;
using GameServer.Hubs;
using Microsoft.AspNetCore.SignalR;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
        .SetIsOriginAllowed(origin => true)
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

builder.Services.AddSignalR();

WebApplication? app = builder.Build();

app.UseCors();

app.MapGet("/", () => "Hello World!");

app.MapHub<GameHub>("/game");

IHubContext<GameHub>? hub = app.Services.GetService<IHubContext<GameHub>>();



ScriptManager.Init();



Game.HubContext = hub!;
await Game.Init();

app.Run();

await Game.Save();
