using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence;

public sealed class UserRepository : IUserRepository
{
    private static readonly List<User> Users = new();

    public void AddUser(User user)
    {
        Users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return Users.SingleOrDefault(user => user.Email == email);
    }
}