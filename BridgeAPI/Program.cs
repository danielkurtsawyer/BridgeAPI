var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IBridgeRepository, BridgeRepository>();
builder.Services.AddScoped<IBridgeService, BridgeService>();
builder.Services.AddScoped<Bridge_ValidateBridgeCreateFilterAttribute>();
builder.Services.AddScoped<Bridge_ValidateBridgeIdFilterAttribute>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();