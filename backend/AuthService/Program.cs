using AuthService.Services;

var b = WebApplication.CreateBuilder(args);
b.Services.AddSingleton<IAuthService, AuthService.Services.AuthService>();
b.Services.AddControllers();
var app = b.Build();
app.MapControllers();
app.Run();
