using Venly.Template.Application.Common;
using Venly.Template.Application.Contracts.Queries;
using Venly.Template.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Venly.Template.Infrastructure.Accounts;
using Venly.Template.Infrastructure.Configuration;
using Venly.Template.Infrastructure.Persistence;

namespace Venly.Template.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, AppSettings settings)
    {
        services.AddScoped<IAccountQueries, AccountQueries>();
        services.AddScoped<IAccountRepository, AccountRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        var connectionString = settings.ConnectionStrings.DatabaseConnectionString;
        services.AddDbContextFactory<ApplicationDbContext>((options) => options.UseSqlServer(connectionString));

        return services;
    }
}