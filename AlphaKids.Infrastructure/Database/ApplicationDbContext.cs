using AlphaKids.Domain.Categories;
using AlphaKids.Domain.Comments;
using AlphaKids.Domain.Posts;
using AlphaKids.Domain.Rates;
using AlphaKids.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AlphaKids.Infrastructure.Database;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Post> Posts { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}

public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer("");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}

