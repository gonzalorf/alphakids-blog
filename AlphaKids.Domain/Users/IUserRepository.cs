namespace AlphaKids.Domain.Users;

public interface IUserRepository
{
    void Add(User user);
    void Remove(User user);
    void Update(User user);
    Task<User> GetById(UserId id);
}
