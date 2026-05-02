using Domain;
using Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;

namespace Repository.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services, string connectionString)
    {
        services.AddTransient<MySqlConnection>(_ => new MySqlConnection(connectionString));

        services.AddScoped<IRepository<Word>, WordRepository>();

        return services;
    }
}
