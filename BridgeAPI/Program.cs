var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IBridgeRepository, BridgeRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();