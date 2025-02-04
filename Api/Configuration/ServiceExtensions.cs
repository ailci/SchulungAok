using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Contracts;
using Persistence.Repositories;
using Service;

namespace Api.Configuration;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureApi(this IServiceCollection services)
    {
        services.AddControllers();  //WebApi
        
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();

        return services;
    }
    
    public static IServiceCollection ConfigureDb(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");

        services.AddDbContext<QotdContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.EnableSensitiveDataLogging();
        });

        return services;
    }

    public static IServiceCollection ConfigureDI(this IServiceCollection services)
    {
        services.AddScoped<IQuoteRepository, QuoteRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IRepositoryManager, RepositoryManager>();

        services.AddScoped<IQotdService, QotdService>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IServiceManager, ServiceManager>();

        return services;
    }
}