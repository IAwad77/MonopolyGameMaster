using GameLogicService.Services;

var b = WebApplication.CreateBuilder(args);
b.Services.AddSingleton<IGameLogicService, GameLogicService.Services.GameLogicService>();
b.Services.AddControllers();
var app = b.Build();
app.MapControllers();
app.Run();
