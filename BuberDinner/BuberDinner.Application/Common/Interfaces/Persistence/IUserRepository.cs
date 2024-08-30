using BuberDinner.Domain.User;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    void AddUser(User user);
    User? GetUserByEmail(string email);
}