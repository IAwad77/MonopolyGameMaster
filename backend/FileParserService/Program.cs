using FileParserService.Services;
var b=WebApplication.CreateBuilder(args);
b.Services.AddSingleton<IFileParserService, FileParserService.Services.FileParserService>();
b.Services.AddControllers();
var app=b.Build();
app.MapControllers();
app.Run();
