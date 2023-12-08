using Microsoft.EntityFrameworkCore;
using NanoBlogEngine.Domain.Categories;
using NanoBlogEngine.Domain.Comments;
using NanoBlogEngine.Domain.Posts;
using NanoBlogEngine.Domain.Rates;
using NanoBlogEngine.Domain.Users;

namespace NanoBlogEngine.Infrastructure.Database;

public interface IApplicationDbContext
{
    DbSet<Post> Posts { get; set; }

    DbSet<Comment> Comments { get; set; }

    DbSet<Rate> Rates { get; set; }

    DbSet<Category> Categories { get; set; }

    DbSet<User> Users { get; set; }
}
