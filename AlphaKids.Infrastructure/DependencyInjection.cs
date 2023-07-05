using AlphaKids.Domain.Categories;
using AlphaKids.Domain.Posts;
using AlphaKids.Domain.SeedWork;
using AlphaKids.Domain.Users;
using AlphaKids.Infrastructure.Database;
using AlphaKids.Infrastructure.Domain;
using AlphaKids.Infrastructure.Domain.Categories;
using AlphaKids.Infrastructure.Domain.Posts;
using AlphaKids.Infrastructure.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlphaKids.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
IConfiguration configuration)
    {
        _ = services.AddDbContext<ApplicationDbContext>(options =>
        {
            _ = options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            //options.UseInMemoryDatabase("Db");
        });

        _ = services.AddScoped<IApplicationDbContext>(option =>
        {
            return option.GetService<ApplicationDbContext>();
        });

        _ = services.AddScoped<IUnitOfWork, UnitOfWork>();

        _ = services.AddScoped<IPostRepository, PostRepository>();
        _ = services.AddScoped<ICategoryRepository, CategoryRepository>();
        _ = services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
