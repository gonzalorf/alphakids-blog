using AlphaKids.Domain.Users;
using AlphaKids.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AlphaKids.Infrastructure.Domain.Users;

public class UserRepository : IUserRepository
{
    private readonly IApplicationDbContext context;

    public UserRepository(IApplicationDbContext context)
    {
        this.context = context;
    }

    public void Add(User user)
    {
        _ = context.Users.Add(user);
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await context.Users.FirstOrDefaultAsync(p => p.Email == email);
    }

    public async Task<User?> GetById(UserId id)
    {
        return await context.Users.FirstOrDefaultAsync(p => p.Id == id);
    }

    public void Remove(User user)
    {
        throw new NotImplementedException();
    }

    public void Update(User user)
    {
        throw new NotImplementedException();
    }
}
