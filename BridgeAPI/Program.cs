var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () => {
   return "This is the root path response"; 
});

app.Run();