using System.Reflection;
using BuberDinner.Application.Authentication.Commands.RegisterUser;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ErrorOr;
using FluentValidation;

namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationInjections(this IServiceCollection services)
    {
        services.AddMediatR(config => { config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}