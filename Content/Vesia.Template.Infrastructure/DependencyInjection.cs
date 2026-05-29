using Vesia.Template.Application.Common;
using Vesia.Template.Application.Contracts.Queries;
using Vesia.Template.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vesia.Template.Infrastructure.Accounts;
using Vesia.Template.Infrastructure.Configuration;
using Vesia.Template.Infrastructure.Persistence;

namespace Vesia.Template.Infrastructure;

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