using NanoBlogEngine.Domain.Users;
using NanoBlogEngine.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using NanoBlogEngine.Domain.Posts;
using Microsoft.Extensions.Hosting;

namespace NanoBlogEngine.Infrastructure.Domain.Users;

public class UserRepository : IUserRepository
{
    private readonly IApplicationDbContext context;

    public UserRepository(IApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task Add(User user)
    {
        _ = await context.Users.AddAsync(user);
    }

    public void Remove(User user)
    {
        _ = context.Users.Remove(user);
    }

    public void Update(User user)
    {
        _ = context.Users.Update(user);
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await context.Users.FirstOrDefaultAsync(p => p.Email == email);
    }

    public async Task<User?> GetById(UserId id)
    {
        return await context.Users.FirstOrDefaultAsync(p => p.Id == id);
    }
}
