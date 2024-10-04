using GerencimentoBiblioteca.Persistence;
using LibraryManager.Core.Repositories;
using LibraryManager.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager.Infraestructure;

public static class InfraestructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddRepositories()
            .AddData(configuration);
        
        return services;
    }

    private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("LibraryManager");

        services.AddDbContext<LibraryManagerDbContext>(o => o.UseSqlServer(connectionString));
        
        return services;
        
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBookLoanRepository, BookLoanRepository>();
        
        return services;
    }
    
}