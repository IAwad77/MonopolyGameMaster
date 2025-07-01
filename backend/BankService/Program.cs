using BankService.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IBankService, BankService.Services.BankService>();
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
app.Run();
