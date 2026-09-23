using Microsoft.Extensions.DependencyInjection;
using Vesia.Dispatch;

namespace Vesia.Template.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Add Vesia.Dispatch or other Application services.
        services.AddDispatch(options =>
        {
            options.CommandLogging = LoggingMode.All;
            options.QueryLogging = LoggingMode.OptIn;
        });

        return services;
    }
}