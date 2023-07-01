using AlphaKids.Domain.Categories;
using AlphaKids.Domain.Posts;
using AlphaKids.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace AlphaKids.Infrastructure.Database;

public interface IApplicationDbContext
{
    DbSet<Post> Posts { get; set; }

    DbSet<Category> Categories { get; set; }

    DbSet<User> Users { get; set; }
}
