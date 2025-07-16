using FluentValidation;
using GraphQL.Models;
using GraphQL.Repository;

namespace GraphQL.Helpers;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IValidator<Employee>, EmployeeValidator>();
        services.AddScoped<IValidator<CreateEmployeeInput>, CreateEmployeeInputValidator>();

        return services;
    }
}
