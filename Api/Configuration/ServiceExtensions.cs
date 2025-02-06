using Api.Filter;
using Logging;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Contracts;
using Persistence.Repositories;
using Service;
using Service.Resolver;

namespace Api.Configuration;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureApi(this IServiceCollection services)
    {
        services.AddControllers(config =>
        {
            //config.Filters.Add<ApiKeyAuthFilter>(); // Globaler Filter
        });  //WebApi
        
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();

        //Automapper
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddTransient<FormFileToByteArrayResolver>();

        //GlobalExceptionHandler
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        //Filter
        services.AddScoped<ApiKeyAuthFilter>();

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

    public static IServiceCollection ConfigureLogger(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();
        return services;
    }
    
    public static IServiceCollection ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
        });

        return services;
    }
}