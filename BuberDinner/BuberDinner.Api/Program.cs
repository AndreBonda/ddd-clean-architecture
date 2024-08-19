using BuberDinner.Api.Middleware;
using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddApplicationInjections()
    .AddInfrastructureInjections(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ErrorHandling>();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();