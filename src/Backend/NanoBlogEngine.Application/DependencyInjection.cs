using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace NanoBlogEngine.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        _ = services.AddMediatR(configuration =>
        {
            _ = configuration.RegisterServicesFromAssemblies(assembly);
        });

        _ = services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
