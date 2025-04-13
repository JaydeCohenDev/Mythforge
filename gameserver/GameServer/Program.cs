

using GameServer.Core;
using GameServer.Core.Database;
using GameServer.Core.Scripting;
using GameServer.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GameDbContext>();

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


Game.HubContext = hub!;
Game.Init();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<GameDbContext>();
    await DbContextPreloader.PreloadDatabaseAsync(context, Console.WriteLine);
}

app.Run();
