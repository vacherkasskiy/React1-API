using Reactjs_api.Data.Models;

namespace Reactjs_api.Repositories.Interfaces;

public interface IUserRepository
{
    public int Length { get; }
    public Task<User?> GetUser(long userId);
    public User[] GetUsers(int skip, int amount);
    public Task EditUser(User newUser);
}