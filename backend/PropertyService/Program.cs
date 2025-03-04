using PropertyService.Services;

var b  = WebApplication.CreateBuilder(args);
b.Services.AddSingleton<PropertyService.Services.PropertyService>();
b.Services.AddControllers();

var app = b.Build();
app.MapControllers();
app.Run();
