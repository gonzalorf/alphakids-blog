using NanoBlogEngine.Domain.Categories;
using NanoBlogEngine.Domain.Posts;
using NanoBlogEngine.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NanoBlogEngine.Application.Outbox;
using NanoBlogEngine.Infrastructure.Interceptors;

namespace NanoBlogEngine.Infrastructure.Database;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    readonly AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor;

    public DbSet<Post> Posts { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<User> Users { get; set; }
    
    public DbSet<OutboxMessage> OutboxMessages { get; set; }

    public ApplicationDbContext(
        DbContextOptions options,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options)
    {
        this.auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(auditableEntitySaveChangesInterceptor);
    }
}

//public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
//{
//    public ApplicationDbContext CreateDbContext(string[] args)
//    {
//        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
//        _ = optionsBuilder.UseSqlServer("Data Source=localhost\\SQLExpress;Initial Catalog=NanoBlog;persist security info=True;Integrated Security=SSPI;Encrypt=false;");

//        return new ApplicationDbContext(optionsBuilder.Options);
//    }
//}

