using Microsoft.Extensions.DependencyInjection;

namespace Vesia.Template.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //Register Application Services here if needed - This will be called during start-up

        return services;
    }
}