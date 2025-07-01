using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlayerService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPlayerService, PlayerService.Services.PlayerService>();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();
