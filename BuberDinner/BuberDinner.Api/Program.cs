using BuberDinner.Api.Filter;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using BuberDinner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BuberDinnerDbContext>(options =>
    options.UseSqlServer()
);

// Remove comment if you want to use error handling filters for handling errors
builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
builder.Services.AddControllers();

builder.Services
    .AddApplicationInjections()
    .AddInfrastructureInjections(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();