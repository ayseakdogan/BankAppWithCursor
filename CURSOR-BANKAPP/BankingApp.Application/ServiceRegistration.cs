using System.Reflection;
using BankingApp.Application.Features.CorporateCustomers.Rules;
using BankingApp.Application.Features.IndividualCustomers.Rules;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Business Rules
        services.AddScoped<IndividualCustomerBusinessRules>();
        services.AddScoped<CorporateCustomerBusinessRules>();

        return services;
    }
}