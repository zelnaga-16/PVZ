using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GameAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GameAPIContext") ?? throw new InvalidOperationException("Connection string 'GameAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
