using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddApplicationInjections()
    .AddInfrastructureInjections();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();