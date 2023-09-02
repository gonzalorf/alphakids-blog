using NanoBlogEngine.Domain.Categories;
using NanoBlogEngine.Domain.Posts;
using NanoBlogEngine.Domain.SeedWork;
using NanoBlogEngine.Domain.Users;
using NanoBlogEngine.Infrastructure.Database;
using NanoBlogEngine.Infrastructure.Domain;
using NanoBlogEngine.Infrastructure.Domain.Categories;
using NanoBlogEngine.Infrastructure.Domain.Posts;
using NanoBlogEngine.Infrastructure.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NanoBlogEngine.Infrastructure.Outbox;
using NanoBlogEngine.Infrastructure.Database.Behaviors;
using NanoBlogEngine.Infrastructure.Interceptors;
using NanoBlogEngine.Application.Common.Services;
using NanoBlogEngine.Infrastructure.Services;

namespace NanoBlogEngine.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
IConfiguration configuration)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        _ = services.AddTransient<IDateTimeService, DateTimeService>();
        _ = services.AddScoped<AuditableEntitySaveChangesInterceptor>();

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
        _ = services.AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>();

        _ = services.AddMediatR(configuration => {
            _ = configuration.RegisterServicesFromAssemblies(assembly);
            _ = configuration.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));
        });

        return services;
    }
}
