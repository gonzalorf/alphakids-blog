using AlphaKids.Domain.Posts;
using AlphaKids.Domain.SeedWork;
using AlphaKids.Infrastructure.Database;
using AlphaKids.Infrastructure.Domain;
using AlphaKids.Infrastructure.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlphaKids.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            //options.UseSqlServer(configuration.GetConnectionString("MyWorldDbConnection"));
            options.UseInMemoryDatabase("Db");
        });

        services.AddScoped<IApplicationDbContext>(option => {
            return option.GetService<ApplicationDbContext>();
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<IPostRepository, PostRepository>();

        return services;
    }
}
